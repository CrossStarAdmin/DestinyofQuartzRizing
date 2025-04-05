using Assets.BEScripts.Domains.Types.Responses;

namespace Assets.FEScripts.Types.Transfer
{
    public class GetEnemiesResponseTransfer
    {
        public static EnemyType[] EnemyTypesTransfer(
            GetEnemiesResponseType response
        )
        {
            if (response == null) return null;
            EnemyType[] enemyTypes = new EnemyType[response.list.Length];
            for (int i = 0; i < response.list.Length; i++)
            {
                enemyTypes[i] = new EnemyType
                {
                    uid = response.list[i].uid,
                    name = response.list[i].name,
                    nameId = response.list[i].nameId,
                    maxHp = response.list[i].maxHp,
                    maxMp = response.list[i].maxMp,
                    attack = response.list[i].attack,
                    defense = response.list[i].defense,
                    speed = response.list[i].speed
                };
            }
            return enemyTypes;
        }
    }
}