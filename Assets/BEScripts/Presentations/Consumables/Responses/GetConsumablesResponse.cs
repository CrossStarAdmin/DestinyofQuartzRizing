using System.Diagnostics;
using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.UseCases.Consumables.Dto;
using UnityEngine;

namespace Assets.BEScripts.Presentations.Consumables.Responses
{
    public class GetConsumablesResponse
    {
        public GetConsumablesResponseType ToResponse(GetConsumablesResponseDto _dto)
        {
            ConsumableDataType[] _consumables = new ConsumableDataType[_dto.consumables.Length];
            for (int i = 0; i < _dto.consumables.Length; i++)
            {
                _consumables[i] = new ConsumableDataType
                {
                    uid = _dto.consumables[i].uid,
                    itemId = _dto.consumables[i].itemId,
                    name = _dto.consumables[i].name,
                    description = _dto.consumables[i].description,
                    jemCount = _dto.consumables[i].jemCount,
                    campaignJemCount = _dto.consumables[i].campaignJemCount,
                    price = _dto.consumables[i].price,
                    campaignPrice = _dto.consumables[i].campaignPrice
                };
            }
            return new GetConsumablesResponseType
            {
                list = _consumables
            };
        }
    }
}