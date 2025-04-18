using Assets.BEScripts.Domains.Types.Responses;
using Assets.FEScripts.Types;
using Assets.FEScripts.Types.Transfer;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Purchase
{
    public class PurchaseEntity : MonoBehaviour
    {
        private GetConsumablesResponseType _getConsumablesResponseType;
        public GetConsumablesResponseType getConsumablesResponseType
        {
            set { _getConsumablesResponseType = value; }
        }

        public ConsumableType[] consumableTypes
        {
            get
            {
                return GetConsumablesResponseTransfer.ConsumableTypesTransfer(_getConsumablesResponseType);
            }
        }
    }
}