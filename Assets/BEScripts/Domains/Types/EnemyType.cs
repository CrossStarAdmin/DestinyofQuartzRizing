using System;
using Assets.BEScripts.Domains.Interfaces.Type.Json;

namespace Assets.BEScripts.Domains.Types.Json
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
        public int maxHp;
        public int maxMp;
        public int attack;
        public int defense;
        public int speed;
    }
}