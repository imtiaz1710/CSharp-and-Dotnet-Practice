using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class UnitOfWork
    {
        public StudentRepository studentRepository;
        public CourseRepository courseRepository;

        private readonly SqlConnection _sqlConnection;
        private readonly SqlTransaction _sqlTransaction;

        public UnitOfWork(SqlConnection connection)
        {
            _sqlConnection = connection;
            _sqlConnection.Open();
            _sqlTransaction = _sqlConnection.BeginTransaction();
            studentRepository = new StudentRepository(connection,_sqlTransaction);
            courseRepository = new CourseRepository(connection, _sqlTransaction);
        }

        public void SaveChange()
        {
            try
            {
                _sqlTransaction.Commit();
            }
            catch
            {
                _sqlTransaction.Rollback();
            }
        }

    }
}
