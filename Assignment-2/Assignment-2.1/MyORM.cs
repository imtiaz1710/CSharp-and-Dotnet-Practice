using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class MyORM<T> where T : IData
    {
        private SqlConnection _sqlConnection;

        public MyORM(SqlConnection connection)
        {
            _sqlConnection = connection;
            
        }
        public MyORM(string connectionString)
            : this(new SqlConnection(connectionString))
        {   
        }
        public MyORM()
            :this (new SqlConnection(DatabaseConnection.getConnectionString()))
        {
            
        }
        public bool IsClassOrCollectionOrArray(PropertyInfo property)
        {
            return ((property.PropertyType.IsClass
                       && property.PropertyType.Assembly.FullName == Assembly.GetExecutingAssembly().FullName) ||
                       (property.PropertyType.Namespace is ("System.Collections.Generic"
                       or "System.Collections") || property.PropertyType.IsArray));
        }
        public bool IsClassOfCurrentAssembly(PropertyInfo property)
        {
            return property.PropertyType.IsClass
                    && property.PropertyType.Assembly.FullName == Assembly.GetExecutingAssembly().FullName;
        }
        public bool IsCollectionOrArray(PropertyInfo property)
        {
            return (property.PropertyType.Namespace is ("System.Collections.Generic"
                    or "System.Collections")) || property.PropertyType.IsArray;
        }
        public void Update(T item)
        {
            var sql = new StringBuilder("Update ");
            var type = typeof(T);
            sql.Append(type.Name).Append(" Set ");
            var properties=type.GetProperties();

            foreach (var property in properties)
            {
                if(!IsClassOrCollectionOrArray(property) && property.GetValue(item)!=null)
                {
                    sql.Append(property.Name).Append(" = @")
                    .Append(property.Name).Append(",");
                }
            }

            sql.Remove(sql.Length - 1, 1);
            sql.Append(" Where id = ").Append(item.Id).Append(";");
            var query = sql.ToString();
            Console.WriteLine(query);

            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }

            using var command = new SqlCommand(query,_sqlConnection);
  
            foreach (var property in properties)
            {
                if (!IsClassOrCollectionOrArray(property) && property.GetValue(item) != null)
                {
                    command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item));
                }
            }

            command.ExecuteNonQuery();

            foreach (var property in properties)
            {
                if (property.PropertyType.IsClass
                    && property.PropertyType.Assembly.FullName == type.Assembly.FullName)
                {


                    Type innerClassType = property.PropertyType;
                    var myOrm = Activator.CreateInstance(typeof(MyORM<>)
                        .MakeGenericType(property.PropertyType));

                    myOrm.GetType().GetMethod("Update", new Type[] { innerClassType })
                        .Invoke(myOrm, new object[] { property.GetValue(item) });
                }
                else if (!IsClassOrCollectionOrArray(property))
                {
                    var collectionType = property.PropertyType.GetGenericArguments()[0];
                    var objectCollection = property.GetValue(item);

                    var myOrm = Activator.CreateInstance(typeof(MyORM<>)
                            .MakeGenericType(collectionType)
                            , DatabaseConnection.getConnectionString());

                    foreach (var signleObject in objectCollection as IEnumerable)
                    {
                        myOrm.GetType().GetMethod("Update", new Type[] { collectionType })
                            .Invoke(myOrm, new object[] { signleObject });
                    }
                }
            }

        }

        public void Insert(T item)
        {
            var sql = new StringBuilder("Insert into ");
            var type = item.GetType();
            var properties = type.GetProperties();

            sql.Append(type.Name);
            sql.Append('(');

            foreach(var property in properties)
            {
                if (!IsClassOrCollectionOrArray(property))
                {
                    sql.Append(' ').Append(property.Name).Append(',');
                } 
            }

            sql.Remove(sql.Length - 1, 1);

            sql.Append(") values(");

            foreach (var property in properties)
            {
                if(!IsClassOrCollectionOrArray(property))
                {
                    sql.Append('@').Append(property.Name).Append(',');
                }
            }

            sql.Remove(sql.Length - 1, 1);
            sql.Append(");");

            var query = sql.ToString();

            Console.WriteLine(query);

            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }

            var command = new SqlCommand(query, _sqlConnection);
            foreach (var property in properties)
            {
                if (!IsClassOrCollectionOrArray(property))
                {
                    command.Parameters.AddWithValue("@" + property.Name, property.GetValue(item));
                }
            }

            command.ExecuteNonQuery();

            foreach (var property in properties)
            {
                if (IsClassOfCurrentAssembly(property))
                {
                    Type innerClassType = property.PropertyType;
                    var myOrm = Activator.CreateInstance(typeof(MyORM<>)
                        .MakeGenericType(property.PropertyType));
                   
                    myOrm.GetType().GetMethod("Insert", new Type[] { innerClassType })
                        .Invoke(myOrm, new object[] { property.GetValue(item) });
                }
                else if (IsClassOrCollectionOrArray(property))
                {
                    var collectionType = property.PropertyType.GetGenericArguments()[0];
                    var objectCollection = property.GetValue(item);

                    var myOrm = Activator.CreateInstance(typeof(MyORM<>)
                            .MakeGenericType(collectionType)
                            , DatabaseConnection.getConnectionString());

                    foreach (var signleObject in objectCollection as IEnumerable)
                    {
                        myOrm.GetType().GetMethod("Insert", new Type[] { collectionType })
                            .Invoke(myOrm, new object[] { signleObject });
                    }
                }
            }
        }

        public void Delete(T item)
        {
            Delete(item.Id);
            var OuterClassType = typeof(T);
            var properties = OuterClassType.GetProperties();
            foreach (var property in properties)
            {
                if (IsClassOfCurrentAssembly(property))
                {
                    Type innerClassType = property.PropertyType;
                    var myOrm = Activator.CreateInstance(typeof(MyORM<>).MakeGenericType(innerClassType)
                        , new object[] { DatabaseConnection.getConnectionString() });
        
                    myOrm.GetType().GetMethod("Delete", new Type[] { innerClassType })
                        .Invoke(myOrm, new object[] { property.GetValue(item) });
                }
                else if(IsClassOrCollectionOrArray(property))
                {
                    var collectionType = property.PropertyType.GetGenericArguments()[0];
                    var objectCollection = property.GetValue(item);

                    var myOrm = Activator.CreateInstance(typeof(MyORM<>)
                            .MakeGenericType(collectionType)
                            ,DatabaseConnection.getConnectionString());

                    foreach (var signleObject in objectCollection as IEnumerable)
                    {
                        myOrm.GetType().GetMethod("Delete", new Type[] { collectionType })
                            .Invoke(myOrm, new object[] { signleObject });
                    }
                }
            }
        }

        public void Delete(int id)
        {
            var type = typeof(T);
            var sql = new StringBuilder();
           
            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }

            var command = new SqlCommand();
            command.Connection = _sqlConnection;

            foreach (var property in type.GetProperties())
            {
                if (property.PropertyType.IsClass
                   && property.PropertyType.Assembly.FullName == type.Assembly.FullName)
                {
                    var myOrm = Activator.CreateInstance(typeof(MyORM<>)
                        .MakeGenericType(property.PropertyType)
                        ,DatabaseConnection.getConnectionString());

                    myOrm.GetType().GetMethod("Delete", new Type[] { typeof(int) })
                        .Invoke(myOrm, new object[] { id });

                }
                else if ((property.PropertyType.Namespace is ("System.Collections.Generic" or "System.Collections"))
                    || property.PropertyType.IsArray)
                {
                    var collectionType = property.PropertyType.GetGenericArguments()[0];
                    sql.Append("Select Id From ").Append(collectionType.Name).Append(" Where ")
                        .Append(type.Name).Append("Id = ")
                        .Append(id).Append(";");
                
                    command.CommandText = sql.ToString();
                    using var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var myOrm = Activator.CreateInstance(typeof(MyORM<>)
                            .MakeGenericType(collectionType)
                            , DatabaseConnection.getConnectionString());

                        myOrm.GetType().GetMethod("Delete", new Type[] { typeof(int) })
                            .Invoke(myOrm, new object[] { reader["Id"] });
                    }
                }
            }

            sql.Clear();
            sql.Append("Delete From ").Append(type.Name)
                .Append(" Where Id = ").Append(id).Append(";");
            command.CommandText = sql.ToString();
            command.ExecuteNonQuery();
        }

        public IList<T> GetAll()
        {
            var type = typeof(T);
            var sql = new StringBuilder("Select * from ");
            sql.Append(type.Name);
            var query = sql.ToString();

            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }

            using var command = new SqlCommand(query, _sqlConnection);
            var reader = command.ExecuteReader();

            var raws = new List<T>();
            var idList =new List<int>();

            while (reader.Read())
            {
                idList.Add((int)reader["id"]);
            }

            foreach (var id in idList)
            {
                raws.Add(GetById(id));
            }
 
            return raws;
        }

        public T GetById(int id)
        {
            var type = typeof(T);

            var sql = new StringBuilder("Select * from ");
            sql.Append(type.Name).Append(" Where id = ")
                .Append(id).Append(";");
            var query = sql.ToString();

            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }

            using var command = new SqlCommand(query,_sqlConnection);
            using var reader=command.ExecuteReader();
            var properties = type.GetProperties();
            var instance=(T)Activator.CreateInstance(type);

            foreach (var property in properties)
            {
                if (property.PropertyType.IsClass
                    && property.PropertyType.Assembly.FullName == type.Assembly.FullName)
                {
                    sql.Clear();
                    sql.Append("Select * from ").Append(property.PropertyType.Name)
                        .Append(" Where id = ").Append(id).Append(";");

                    using var command2 = new SqlCommand(sql.ToString(), _sqlConnection);
                    using var objectReader = command2.ExecuteReader();
                    objectReader.Read();

                    var myOrm = Activator.CreateInstance(typeof(MyORM<>).MakeGenericType(property.PropertyType)
                        , new object[] { DatabaseConnection.getConnectionString() });

                    var method = myOrm.GetType().GetMethod("GetById", new Type[] { typeof(int) });
                    var nestedInstance = method.Invoke(myOrm, new object[] { objectReader["Id"] });
                    property.SetValue(instance, nestedInstance);
                }

                else if ((property.PropertyType.Namespace is ("System.Collections.Generic" or "System.Collections"))
                    || property.PropertyType.IsArray)
                {
                    sql.Clear();
                    var collectionType = property.PropertyType.GetGenericArguments()[0];

                    sql.Append("Select * from ").Append(collectionType.Name)
                        .Append(" Where ").Append(type.Name).Append("Id = ").Append(id).Append(";");

                    using var command1 = new SqlCommand(sql.ToString(), _sqlConnection);
                    var objectCollection = Activator.CreateInstance((typeof(List<>))
                        .MakeGenericType(collectionType), new object[0]);

                    using var collectionReader = command1.ExecuteReader();

                    while (collectionReader.Read())
                    {
                        var CollectionUnit = Activator.CreateInstance(collectionType);
                       
                        var myOrm = Activator.CreateInstance(typeof(MyORM<>).MakeGenericType(collectionType)
                        , new object[] { DatabaseConnection.getConnectionString() });

                        var method = myOrm.GetType().GetMethod("GetById", new Type[] { typeof(int) });
                        CollectionUnit =  method.Invoke(myOrm, new object[] { collectionReader["Id"] });

                        objectCollection.GetType().GetMethod("Add", new Type[] { collectionType })
                            .Invoke(objectCollection, new object[] { CollectionUnit });
                    }

                    property.SetValue(instance, objectCollection);
                }
                else 
                    property.SetValue(instance, reader[property.Name]);
            }
            return instance;
        }
    }
}
