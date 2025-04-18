using System.Diagnostics;
using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.UseCases.NoConsumables.Dto;
using UnityEngine;

namespace Assets.BEScripts.Presentations.NoConsumables.Responses
{
    public class GetNoConsumablesResponse
    {
        public GetNoConsumablesResponseType ToResponse(GetNoConsumablesResponseDto _dto)
        {
            ConsumableDataType[] _noConsumables = new ConsumableDataType[_dto.noConsumables.Length];
            for (int i = 0; i < _dto.noConsumables.Length; i++)
            {
                _noConsumables[i] = new ConsumableDataType
                {
                    uid = _dto.noConsumables[i].uid,
                    itemId = _dto.noConsumables[i].itemId,
                    name = _dto.noConsumables[i].name,
                    description = _dto.noConsumables[i].description,
                    jemCount = _dto.noConsumables[i].jemCount,
                    campaignJemCount = _dto.noConsumables[i].campaignJemCount,
                };
            }
            return new GetNoConsumablesResponseType
            {
                list = _noConsumables
            };
        }
    }
}