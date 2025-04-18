using Assets.BEScripts.Domains.Entities;

namespace Assets.BEScripts.UseCases.Subscriptions.Dto
{
    public class GetSubscriptionsResponseDto
    {
        private SubscriptionEntity[] _subscriptions;

        public GetSubscriptionsResponseDto(
            SubscriptionEntity[] subscriptions
        )
        {
            _subscriptions = subscriptions;
        }

        public SubscriptionEntity[] subscriptions
        {
            get { return _subscriptions; }
        }
    }
}