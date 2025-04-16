namespace Assets.FEScripts.Types
{
    [System.Serializable]
    public class ConsumableType
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