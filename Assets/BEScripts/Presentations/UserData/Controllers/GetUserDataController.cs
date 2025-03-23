using Assets.BEScripts.Presentations.UserData.Requests;
using Assets.BEScripts.Presentations.UserData.Responses;
using Assets.BEScripts.UseCases.UserData.Dto;
using Assets.BEScripts.UseCases.UserData.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.UserData.Controllers
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