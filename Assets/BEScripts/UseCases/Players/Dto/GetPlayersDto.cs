using Assets.BEScripts.Domains.Entities;

namespace Assets.BEScripts.UseCases.Players.Dto
{
    public class GetPlayersResponseDto
    {
        private PlayerEntity[] _players;

        public GetPlayersResponseDto(
            PlayerEntity[] players
        )
        {
            _players = players;
        }

        public PlayerEntity[] players
        {
            get { return _players; }
        }
    }
}