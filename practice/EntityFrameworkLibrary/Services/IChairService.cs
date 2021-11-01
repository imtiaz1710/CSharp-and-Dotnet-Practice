using EntityFrameworkLibrary.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary.Services
{
    public interface IChairService
    {
        public IList<Chair> GetAllChairs();

    }
}
