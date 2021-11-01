using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class StudentRepository : IRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlTransaction _sqlTransaction;

        public StudentRepository(SqlConnection connection , SqlTransaction sqlTransaction)
        {
            _sqlConnection = connection;
            _sqlTransaction = sqlTransaction;
        }

        public void Create(string sql)
        {
            using var command = new SqlCommand(sql , _sqlConnection , _sqlTransaction);
            command.ExecuteNonQuery();
        }
    }
}
