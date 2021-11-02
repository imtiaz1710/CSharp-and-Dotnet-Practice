using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ConverterXmlToJsonByDataTable
{
    class Program
    {
        private const string connectionString =
            "Server=DESKTOP-JO34CC1\\SQLEXPRESS;Database=Practice;User Id=demo;Password=123456;";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(connectionString);
            DataTableExample(connection);
        }

        public static void DataTableExample(SqlConnection connection)
        {
            var dataTable = new DataTable()
            {
                TableName = "MyTable"
            };

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("age", typeof(int));

            var dataRow = dataTable.NewRow();
            dataRow["Name"] = "Muhit";
            dataRow["age"] = 3;

            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["Name"] = "Mukit";
            dataRow["age"] = 7;

            dataTable.Rows.Add(dataRow);

            dataTable.WriteXml(@"G:\DevskillDotNetCourse\aspnet-b5-personal\ADONetPractice\data.xml");
            var json = JsonConvert.SerializeObject(dataTable);
            File.WriteAllText(@"G:\DevskillDotNetCourse\aspnet-b5-personal\ADONetPractice\Data.json", json);

             /*SqlDataAdapter adapter = new SqlDataAdapter("select * from student", connection);
             SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
             builder.GetInsertCommand();
             adapter.Update(dataTable);*/
        }
    }
}
