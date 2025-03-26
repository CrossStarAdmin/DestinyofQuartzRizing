using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.UseCases.Enemies.Dto;

namespace Assets.BEScripts.Presentations.Enemies.Responses
{
    public class GetEnemiesResponse
    {
        public GetEnemiesResponseType ToResponse(GetEnemiesResponseDto _dto)
        {
            EnemyDataType[] _enemies = new EnemyDataType[_dto.enemies.Length];
            for (int i = 0; i < _dto.enemies.Length; i++)
            {
                _enemies[i] = new EnemyDataType
                {
                    uid = _dto.enemies[i].uid,
                    maxHp = _dto.enemies[i].maxHp,
                    maxMp = _dto.enemies[i].maxMp,
                    attack = _dto.enemies[i].attack,
                    defense = _dto.enemies[i].defense,
                    speed = _dto.enemies[i].speed
                };
            }
            return new GetEnemiesResponseType
            {
                list = _enemies
            };
        }
    }
}