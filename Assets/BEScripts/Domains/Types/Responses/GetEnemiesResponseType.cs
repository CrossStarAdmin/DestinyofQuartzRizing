namespace Assets.BEScripts.Domains.Types.Responses
{
    [System.Serializable]
    public class GetEnemiesResponseType
    {
        public EnemyDataType[] list;
    }

    [System.Serializable]
    public class EnemyDataType
    {
        public string uid;
        public string name;
        public string nameId;
        public int maxHp;
        public int maxMp;
        public int attack;
        public int defense;
        public int speed;
    }
}