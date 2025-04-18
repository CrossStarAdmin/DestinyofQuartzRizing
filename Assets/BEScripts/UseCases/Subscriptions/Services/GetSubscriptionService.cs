using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.Subscriptions.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Subscriptions.Services
{
    public class GetSubscriptionsService
    {
        private readonly SubscriptionRepository _subscriptionRepository;

        public GetSubscriptionsService(
            SubscriptionRepository subscriptionRepository
        )
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async UniTask<GetSubscriptionsResponseDto> Execute()
        {
            SubscriptionEntity[] result = await _subscriptionRepository.FindAll();
            return new GetSubscriptionsResponseDto(result);
        }
    }
}