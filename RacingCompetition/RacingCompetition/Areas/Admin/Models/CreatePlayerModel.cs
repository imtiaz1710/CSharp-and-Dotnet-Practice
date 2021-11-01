using Autofac;
using RacingCompetition.RacingData.BusinessObjects;
using RacingCompetition.RacingData.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace RacingCompetition.Areas.Admin.Models
{
    public class CreatePlayerModel
    {
        [Required, MaxLength(200, ErrorMessage = "Player Name should be less than 200 charcaters")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Player Address should be less than 200 charcaters")]
        public string Address { get; set; }

        private readonly IPlayerService _playerService;

        public CreatePlayerModel()
        {
            _playerService = Startup.AutofacContainer.Resolve<IPlayerService>();
        }

        public CreatePlayerModel(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        internal void CreatePlayer()
        {
            var player = new Player
            {
                Name = Name,
                DateOfBirth = DateOfBirth,
                Address = Address
            };

            _playerService.CreatePlayer(player);
        }
    }
}
