using System;
using Assets.BEScripts.Domains.Types.Json;

namespace Assets.BEScripts.Domains.Entities
{
    public class Enemy
    {
        private string _uid;
        private int _maxHp;
        private int _maxMp;
        private int _attack;
        private int _defense;
        private int _speed;

        public Enemy(
            string uid,
            int maxHp,
            int maxMp,
            int attack,
            int defense,
            int speed
        )
        {
            _uid = uid;
            _maxHp = maxHp;
            _maxMp = maxMp;
            _attack = attack;
            _defense = defense;
            _speed = speed;
        }

        public static Enemy CreateFromModel(EnemyListType _param)
        {
            return new Enemy(
                _param.uid,
                _param.maxHp,
                _param.maxMp,
                _param.attack,
                _param.defense,
                _param.speed
            );
        }

        /// <summary>
        /// UID
        /// </summary>
        public string uid
        {
            get { return _uid; }
        }

        /// <summary>
        /// 最大HP
        /// </summary>
        public int maxHp
        {
            get { return _maxHp; }
        }

        /// <summary>
        /// 最大MP
        /// </summary>
        public int maxMp
        {
            get { return _maxMp; }
        }

        /// <summary>
        /// 攻撃
        /// </summary>
        public int attack
        {
            get { return _attack; }
        }

        /// <summary>
        /// 防御
        /// </summary>
        public int defense
        {
            get { return _defense; }
        }

        /// <summary>
        /// 素早さ
        /// </summary>
        public int speed
        {
            get { return _speed; }
        }
    }
}