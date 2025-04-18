using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.Presentations.Subscriptions.Responses;
using Assets.BEScripts.UseCases.Subscriptions.Dto;
using Assets.BEScripts.UseCases.Subscriptions.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Subscriptions.Controllers
{
    public class GetSubscriptionsController
    {
        private readonly GetSubscriptionsService _getSubscriptionsService;
        public GetSubscriptionsController(
            GetSubscriptionsService getSubscriptionsService
        )
        {
            _getSubscriptionsService = getSubscriptionsService;
        }

        public async UniTask<GetSubscriptionsResponseType> Execute()
        {
            GetSubscriptionsResponse response = new GetSubscriptionsResponse();
            GetSubscriptionsResponseDto dto = await _getSubscriptionsService.Execute();
            return response.ToResponse(dto);
        }
    }
}