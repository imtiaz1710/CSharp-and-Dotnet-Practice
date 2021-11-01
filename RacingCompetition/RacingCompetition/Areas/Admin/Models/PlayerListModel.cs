using Autofac;
using RacingCompetition.Models;
using RacingCompetition.RacingData.Services;
using System.Linq;

namespace RacingCompetition.Areas.Admin.Models
{
    public class PlayerListModel
    {
        private IPlayerService _playerService;

        public PlayerListModel()
        {
            _playerService = Startup.AutofacContainer.Resolve<IPlayerService>();
        }

       /* public PlayerListModel(IPlayerService playerService)
        {
            _playerService = playerService;
        }
*/
        internal object GetPlayers(DataTablesAjaxRequestModel tableModel)
        {
            var data = _playerService.GetPlayers( 
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] {"Id", "Name", "DateOfBirth", "Address" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name,
                                record.DateOfBirth.Date.ToString(),
                                record.Address,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void Delete(int id)
        {
            _playerService.DeletePlayer(id);
        }
    }
}
