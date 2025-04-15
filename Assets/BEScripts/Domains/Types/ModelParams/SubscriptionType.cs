using System;
using Assets.BEScripts.Domains.Interfaces.Types.ModelParams;

namespace Assets.BEScripts.Domains.Types.ModelParams
{
    [Serializable]
    public class SubscriptionModelType : ModelTypeInterface<SubscriptionListType>
    {
        public SubscriptionListType[] list { get; set; }
    }

    [Serializable]
    public class SubscriptionListType : ListTypeInterface
    {
        public string uid { get; set; }
        public string itemId;
        public string name;
        public string description;
        public uint price;
        public uint campaignPrice;
    }
}