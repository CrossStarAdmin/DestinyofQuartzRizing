using Assets.BEScripts.Domains.Types.ModelParams;

namespace Assets.BEScripts.Domains.Entities
{
    public class ConsumableEntity
    {
        private string _uid;
        private string _itemId;
        private string _name;
        private string _description;
        private uint _jemCount;
        private uint _campaignJemCount;
        private uint _price;
        private uint _campaignPrice;

        public ConsumableEntity(
            string uid,
            string itemId,
            string name,
            string description,
            uint jemCount,
            uint campaignJemCount,
            uint price,
            uint campaignPrice
        )
        {
            _uid = uid;
            _itemId = itemId;
            _name = name;
            _description = description;
            _jemCount = jemCount;
            _campaignJemCount = campaignJemCount;
            _price = price;
            _campaignPrice = campaignPrice;
        }

        public static ConsumableEntity CreateFromModel(ConsumableListType _param)
        {
            return new ConsumableEntity(
                _param.uid,
                _param.itemId,
                _param.name,
                _param.description,
                _param.jemCount,
                _param.campaignJemCount,
                _param.price,
                _param.campaignPrice
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
        /// アイテムID
        /// </summary>
        public string itemId
        {
            get { return _itemId; }
        }

        /// <summary>
        /// 名前
        /// </summary>
        public string name
        {
            get { return _name; }
        }

        /// <summary>
        /// 説明
        /// </summary>
        public string description
        {
            get { return _description; }
        }

        /// <summary>
        /// ジェム数
        /// </summary>
        public uint jemCount
        {
            get { return _jemCount; }
        }

        /// <summary>
        /// キャンペーンジェム数
        /// </summary>
        public uint campaignJemCount
        {
            get { return _campaignJemCount; }
        }

        /// <summary>
        /// 価格
        /// </summary>
        public uint price
        {
            get { return _price; }
        }

        /// <summary>
        /// キャンペーン価格
        /// </summary>
        public uint campaignPrice
        {
            get { return _campaignPrice; }
        }
    }
}