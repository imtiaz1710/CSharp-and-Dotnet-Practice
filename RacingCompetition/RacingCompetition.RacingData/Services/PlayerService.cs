using AutoMapper;
using RacingCompetition.RacingData.BusinessObjects;
using RacingCompetition.RacingData.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace RacingCompetition.RacingData.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRacingDataUnitOfWork _racingDataUnitOfWork;
        private readonly IMapper _mapper;

        public PlayerService(IRacingDataUnitOfWork racingDataUnitOfWork, IMapper mapper)
        {
            _racingDataUnitOfWork = racingDataUnitOfWork;
            _mapper = mapper;
        }

        public IList<Player> GetAllPlayers()
        {
            var playerEntities = _racingDataUnitOfWork.Players.GetAll();
            var players = new List<Player>();

            foreach (var entity in playerEntities)
            {
                players.Add(_mapper.Map<Player>(entity));
            }

            return players;
        }

        public void CreatePlayer(Player player)
        {
            if (player == null)
                throw new NullReferenceException("Player is Null");

            _racingDataUnitOfWork.Players.Add(
                _mapper.Map<RacingCompetition.RacingData.Entities.Player>(player)
            );

            _racingDataUnitOfWork.Save();
        }

        public (IList<Player> records, int total, int totalDisplay) GetPlayers(int pageIndex, int pageSize,
            string searchText, string sortText)
        {
            var playerData = _racingDataUnitOfWork.Players.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from player in playerData.data
                              select _mapper.Map<Player>(player)).ToList();

            return (resultData, playerData.total, playerData.totalDisplay);
        }

        public Player GetPlayer(int id)
        {
            var player = _racingDataUnitOfWork.Players.GetById(id);

            if (player == null) return null;

            return _mapper.Map<Player>(player);
        }

        public void UpdatePlayer(Player player)
        {
            var playerEntity = _racingDataUnitOfWork.Players.GetById(player.Id);

            if (playerEntity != null)
            {
                _mapper.Map(player, playerEntity);
                _racingDataUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find player");
        }

        public void DeletePlayer(int id)
        {
            _racingDataUnitOfWork.Players.Remove(id);
            _racingDataUnitOfWork.Save();
        }
    }
}
