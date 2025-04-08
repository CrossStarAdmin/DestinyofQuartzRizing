namespace Assets.BEScripts.Domains.Types.Responses
{
    [System.Serializable]
    public class GetPlayersResponseType
    {
        public PlayerDataType[] list;
    }

    [System.Serializable]
    public class PlayerDataType
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