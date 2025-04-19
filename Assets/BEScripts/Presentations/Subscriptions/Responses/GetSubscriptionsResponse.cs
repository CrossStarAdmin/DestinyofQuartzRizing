using System.Diagnostics;
using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.UseCases.Subscriptions.Dto;
using UnityEngine;

namespace Assets.BEScripts.Presentations.Subscriptions.Responses
{
    public class GetSubscriptionsResponse
    {
        public GetSubscriptionsResponseType ToResponse(GetSubscriptionsResponseDto _dto)
        {
            SubscriptionDataType[] _subscriptions = new SubscriptionDataType[_dto.subscriptions.Length];
            for (int i = 0; i < _dto.subscriptions.Length; i++)
            {
                _subscriptions[i] = new SubscriptionDataType
                {
                    uid = _dto.subscriptions[i].uid,
                    itemId = _dto.subscriptions[i].itemId,
                    name = _dto.subscriptions[i].name,
                    description = _dto.subscriptions[i].description,
                    price = _dto.subscriptions[i].price,
                    campaignPrice = _dto.subscriptions[i].campaignPrice,
                };
            }
            return new GetSubscriptionsResponseType
            {
                list = _subscriptions
            };
        }
    }
}