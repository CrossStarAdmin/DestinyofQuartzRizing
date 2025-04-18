namespace Assets.BEScripts.Domains.Types.Responses
{
    [System.Serializable]
    public class GetSubscriptionsResponseType
    {
        public SubscriptionDataType[] list;
    }

    [System.Serializable]
    public class SubscriptionDataType
    {
        public string uid;
        public string itemId;
        public string name;
        public string description;
        public uint price;
        public uint campaignPrice;
    }
}