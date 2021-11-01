using EntityFrameworkLibrary.BusinessObject;
using EntityFrameworkLibrary.contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary.Services
{
    public class ChairService : IChairService
    {

        private ClassRoomDbContext _classRoomDbContext;

        public ChairService(ClassRoomDbContext classRoomDbContext)
        {
            _classRoomDbContext = classRoomDbContext;
        }

        public IList<Chair> GetAllChairs()
        {
            var ChairEntities= _classRoomDbContext.Chairs.ToList();
            var Chairs = new List<Chair>();

            foreach (var entity in ChairEntities)
            {
                var Chair = new Chair()
                {
                    Id = entity.Id,
                    Color = entity.Color
                };
                Chairs.Add(Chair);
            }

            return Chairs;
        }
    }
}
