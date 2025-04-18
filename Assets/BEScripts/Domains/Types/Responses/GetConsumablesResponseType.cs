namespace Assets.BEScripts.Domains.Types.Responses
{
    [System.Serializable]
    public class GetConsumablesResponseType
    {
        public ConsumableDataType[] list;
    }

    [System.Serializable]
    public class ConsumableDataType
    {
        public string uid;
        public string itemId;
        public string name;
        public string description;
        public uint jemCount;
        public uint campaignJemCount;
        public uint price;
        public uint campaignPrice;
    }
}