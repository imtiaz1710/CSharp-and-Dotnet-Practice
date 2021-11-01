using EntityFrameworkLibrary.BusinessObject;
using EntityFrameworkLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace WebAppPractice.Areas.Admin.Models
{
    public class ChairListModel
    {
        private IChairService _chairService;

        public IList<Chair> Chairs { get; set; }

        public ChairListModel()
        {
            _chairService = Startup.AutofacContainer.Resolve<IChairService>();
        }

        public ChairListModel(IChairService chairService)
        {
            _chairService = chairService;
        }

        public void GetChairModel()
        {
            Chairs = _chairService.GetAllChairs();
        }

    }
}
