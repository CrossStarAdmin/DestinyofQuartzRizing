using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.UseCases.Players.Dto;

namespace Assets.BEScripts.Presentations.Players.Responses
{
    public class GetPlayersResponse
    {
        public GetPlayersResponseType ToResponse(GetPlayersResponseDto dto)
        {
            PlayerDataType[] _players = new PlayerDataType[dto.players.Length];
            for (int i = 0; i < dto.players.Length; i++)
            {
                _players[i] = new PlayerDataType
                {
                    uid = dto.players[i].uid,
                    name = dto.players[i].name,
                    nameId = dto.players[i].nameId,
                    maxHp = dto.players[i].maxHp,
                    maxMp = dto.players[i].maxMp,
                    attack = dto.players[i].attack,
                    defense = dto.players[i].defense,
                    speed = dto.players[i].speed
                };
            }
            return new GetPlayersResponseType
            {
                list = _players
            };
        }
    }
}