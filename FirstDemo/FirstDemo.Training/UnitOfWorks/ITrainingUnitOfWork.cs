using FirstDemo.Data;
using FirstDemo.Training.Contexts;
using FirstDemo.Training.Entities;
using FirstDemo.Training.Repositories;

namespace FirstDemo.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork : IUnitOfWork
    {
        IStudentRepository Students { get; }
        ICourseRepository  Courses { get; }
    }
}