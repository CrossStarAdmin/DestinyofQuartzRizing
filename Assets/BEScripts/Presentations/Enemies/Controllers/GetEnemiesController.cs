using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.Presentations.Enemies.Responses;
using Assets.BEScripts.UseCases.Enemies.Dto;
using Assets.BEScripts.UseCases.Enemies.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Enemies.Controllers
{
    public class GetEnemiesController
    {
        private readonly GetEnemiesService _getEnemiesService;
        public GetEnemiesController(
            GetEnemiesService getEnemiesService
        )
        {
            _getEnemiesService = getEnemiesService;
        }

        public async UniTask<GetEnemiesResponseType> Execute()
        {
            GetEnemiesResponse response = new GetEnemiesResponse();
            GetEnemiesResponseDto dto = await _getEnemiesService.Execute();
            return response.ToResponse(dto);
        }
    }
}