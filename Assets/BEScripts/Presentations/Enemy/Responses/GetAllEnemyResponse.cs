using Assets.BEScripts.UseCases.Enemy.Dto;

namespace Assets.BEScripts.Presentations.Enemy.Responses
{
    [System.Serializable]
    public class GetAllEnemyResponseType
    {
        public EnemyDataType[] list;
    }

    [System.Serializable]
    public class EnemyDataType
    {
        public string uid;
        public int maxHp;
        public int maxMp;
        public int attack;
        public int defense;
        public int speed;
    }

    public class GetAllEnemyResponse
    {
        public GetAllEnemyResponseType ToResponse(GetAllEnemyResponseDto _dto)
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
            return new GetAllEnemyResponseType
            {
                list = _enemies
            };
        }
    }
}