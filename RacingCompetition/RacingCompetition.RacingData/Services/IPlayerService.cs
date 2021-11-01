using RacingCompetition.RacingData.BusinessObjects;
using System.Collections.Generic;

namespace RacingCompetition.RacingData.Services
{
    public interface IPlayerService
    {
        void CreatePlayer(Player player);
        void DeletePlayer(int id);
        IList<Player> GetAllPlayers();
        Player GetPlayer(int id);

        (IList<Player> records, int total, int totalDisplay) GetPlayers(
            int pageIndex, int pageSize, string searchText, string sortText);

        void UpdatePlayer(Player player);
    }
}