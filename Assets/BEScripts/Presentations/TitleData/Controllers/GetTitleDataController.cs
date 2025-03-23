using Assets.BEScripts.Presentations.TitleData.Requests;
using Assets.BEScripts.Presentations.TitleData.Responses;
using Assets.BEScripts.UseCases.TitleData.Dto;
using Assets.BEScripts.UseCases.TitleData.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.TitleData.Controllers
{
    public class GetTitleDataController
    {
        private readonly GetTitleDataService _getTitleDataService;
        public GetTitleDataController(
            GetTitleDataService getTitleDataService
        )
        {
            _getTitleDataService = getTitleDataService;
        }

        public async UniTask<GetTitleDataResponse> Execute(
            GetTitleDataRequest request
        )
        {
            GetTitleDataRequestDto requestDto = new GetTitleDataRequestDto(request);
            GetTitleDataResponseDto result = await _getTitleDataService.Execute(requestDto);
            return new GetTitleDataResponse()
            {
                data = result.data
            };
        }
    }
}