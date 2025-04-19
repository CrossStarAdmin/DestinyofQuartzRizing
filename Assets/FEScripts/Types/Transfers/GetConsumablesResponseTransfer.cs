using Assets.BEScripts.Domains.Types.Responses;

namespace Assets.FEScripts.Types.Transfer
{
    public class GetConsumablesResponseTransfer
    {
        public static ConsumableType[] ConsumableTypesTransfer(
            GetConsumablesResponseType response
        )
        {
            if (response == null) return null;
            ConsumableType[] consumableTypes = new ConsumableType[response.list.Length];
            for (int i = 0; i < response.list.Length; i++)
            {
                consumableTypes[i] = new ConsumableType
                {
                    uid = response.list[i].uid,
                    itemId = response.list[i].itemId,
                    name = response.list[i].name,
                    description = response.list[i].description,
                    jemCount = response.list[i].jemCount,
                    campaignJemCount = response.list[i].campaignJemCount,
                    price = response.list[i].price,
                    campaignPrice = response.list[i].campaignPrice
                };
            }
            return consumableTypes;
        }
    }
}