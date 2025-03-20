using Assets.BEScripts.Presentations.Requests;
using Assets.BEScripts.Presentations.Responses;
using Assets.BEScripts.UseCases.Dto;
using Assets.BEScripts.UseCases.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Controllers
{
    public class GetUserDataController
    {
        private readonly GetUserDataService _getUserDataService;
        public GetUserDataController(
            GetUserDataService getUserDataService
        )
        {
            _getUserDataService = getUserDataService;
        }

        public async UniTask<GetUserDataResponse> Execute(
            GetUserDataRequest request
        )
        {
            GetUserDataRequestDto requestDto = new GetUserDataRequestDto(request);
            GetUserDataResponseDto result = await _getUserDataService.Execute(requestDto);
            return new GetUserDataResponse()
            {
                data = result.data
            };
        }
    }
}