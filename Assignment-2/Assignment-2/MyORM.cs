using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        public void Update(T item)
        {
            var sql = new StringBuilder("Update ");
            var type = typeof(T);
            sql.Append(type.Name).Append(" Set ");
            var properties=type.GetProperties();

            foreach (var property in properties)
            {
                sql.Append(property.Name).Append(" = @")
                    .Append(property.Name).Append(",");
            }

            sql.Remove(sql.Length - 1, 1);
            sql.Append(" Where id = ").Append(item.Id).Append(";");
            var query = sql.ToString();

            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }

            using var command = new SqlCommand(query,_sqlConnection);
  
            foreach (var property in properties)
            {
                command.Parameters.AddWithValue("@"+property.Name,property.GetValue(item));
            }

            command.ExecuteNonQuery();

            if(_sqlConnection.State==System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
                _sqlConnection.Dispose();
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
                sql.Append(' ').Append(property.Name).Append(',');
            }

            sql.Remove(sql.Length - 1, 1);
            sql.Append(") values(");

            foreach(var property in properties)
            {
                sql.Append('@').Append(property.Name).Append(',');
            }

            sql.Remove(sql.Length - 1, 1);
            sql.Append(");");
            var query = sql.ToString();

            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }

            var command = new SqlCommand(query, _sqlConnection);

            foreach (var property in properties)
            {
                command.Parameters.AddWithValue("@"+property.Name,property.GetValue(item));
            }

            command.ExecuteNonQuery();

            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
        }

        public void Delete(T item)
        {
            Delete(item.Id);
        }

        public void Delete(int id)
        {
            var sql = new StringBuilder("Delete from ");
            var type = typeof(T);
            sql.Append(type.Name).Append(" where id = ")
                .Append(id).Append("");
            var query=sql.ToString();

            if (_sqlConnection.State != System.Data.ConnectionState.Open)
            {
                _sqlConnection.Open();
            }

            var command = new SqlCommand(query,_sqlConnection);
            command.ExecuteNonQuery();

            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
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
            using var reader = command.ExecuteReader();
            var raws = new List<T>();

            while (reader.Read())
            {
                raws.Add(GetById((int)reader["id"]));
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

            using var command = new SqlCommand(query, _sqlConnection);
            using var reader=command.ExecuteReader();
            var properties = type.GetProperties();
            var constructor = type.GetConstructor(new Type[0]);
            var  instance= (T)constructor.Invoke(new object[0]);           //need further checking...
            reader.Read();
             
            foreach (var property in properties)
            {
                property.SetValue(instance, reader[property.Name]);
            }

            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }

            return instance;
        }
    }
}
