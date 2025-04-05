using System;
using Assets.BEScripts.Domains.Interfaces.Types.ModelParams;

namespace Assets.BEScripts.Domains.Types.ModelParams
{
    [Serializable]
    public class PlayerModelType : ModelTypeInterface<PlayerListType>
    {
        public PlayerListType[] list { get; set; }
    }

    [Serializable]
    public class PlayerListType : ListTypeInterface
    {
        public string uid { get; set; }
        public string name;
        public string nameId;
        public int maxHp;
        public int maxMp;
        public int attack;
        public int defense;
        public int speed;
    }
}