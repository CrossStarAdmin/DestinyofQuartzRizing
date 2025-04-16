namespace Assets.BEScripts.Domains.Types.Responses
{
    [System.Serializable]
    public class GetNoConsumablesResponseType
    {
        public ConsumableDataType[] list;
    }

    [System.Serializable]
    public class NoConsumableDataType
    {
        public string uid;
        public string itemId;
        public string name;
        public string description;
        public uint jemCount;
        public uint campaignJemCount;
    }
}