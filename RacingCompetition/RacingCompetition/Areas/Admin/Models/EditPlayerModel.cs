using Autofac;
using RacingCompetition.RacingData.BusinessObjects;
using RacingCompetition.RacingData.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace RacingCompetition.Areas.Admin.Models
{
    public class EditPlayerModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Player Name should be less than 200 charcaters")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Player Address should be less than 200 charcaters")]
        public string Address { get; set; }


        private readonly IPlayerService _playerService;

        public EditPlayerModel()
        {
            _playerService = Startup.AutofacContainer.Resolve<IPlayerService>();
        }
        
        public EditPlayerModel(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void LoadModelData(int id)
        {
            var player = _playerService.GetPlayer(id);
            Id = player?.Id;
            Name = player.Name;
            DateOfBirth = player?.DateOfBirth;
        }

        internal void Update()
        {
            var player = new Player
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                DateOfBirth = DateOfBirth.HasValue ? DateOfBirth.Value : DateTime.MinValue,
                Address = Address
            };

            _playerService.UpdatePlayer(player);
        }
    }
}
