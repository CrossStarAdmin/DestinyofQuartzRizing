using System;
using Assets.BEScripts.Domains.Interfaces.Types.ModelParams;

namespace Assets.BEScripts.Domains.Types.ModelParams
{
    [Serializable]
    public class EnemyModelType : ModelTypeInterface<EnemyListType>
    {
        public EnemyListType[] list { get; set; }
    }

    [Serializable]
    public class EnemyListType : ListTypeInterface
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