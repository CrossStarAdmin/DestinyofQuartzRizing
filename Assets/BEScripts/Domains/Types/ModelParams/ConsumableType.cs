using System;
using Assets.BEScripts.Domains.Interfaces.Types.ModelParams;

namespace Assets.BEScripts.Domains.Types.ModelParams
{
    [Serializable]
    public class ConsumableModelType : ModelTypeInterface<ConsumableListType>
    {
        public ConsumableListType[] list { get; set; }
    }

    [Serializable]
    public class ConsumableListType : ListTypeInterface
    {
        public string uid { get; set; }
        public string itemId;
        public string name;
        public string description;
        public uint jemCount;
        public uint campaignJemCount;
        public uint price;
        public uint campaignPrice;
    }
}