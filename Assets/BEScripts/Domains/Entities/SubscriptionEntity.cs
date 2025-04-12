using Assets.BEScripts.Domains.Types.ModelParams;

namespace Assets.BEScripts.Domains.Entities
{
    public class SubscriptionEntity
    {
        private string _uid;
        private string _itemId;
        private string _name;
        private string _description;
        private uint _price;
        private uint _campaignPrice;

        public SubscriptionEntity(
            string uid,
            string itemId,
            string name,
            string description,
            uint price,
            uint campaignPrice
        )
        {
            _uid = uid;
            _itemId = itemId;
            _name = name;
            _description = description;
            _price = price;
            _campaignPrice = campaignPrice;
        }

        public static SubscriptionEntity CreateFromModel(SubscriptionListType _param)
        {
            return new SubscriptionEntity(
                _param.uid,
                _param.itemId,
                _param.name,
                _param.description,
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