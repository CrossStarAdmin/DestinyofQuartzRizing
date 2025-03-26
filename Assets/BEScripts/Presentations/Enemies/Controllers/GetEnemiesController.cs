using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.Presentations.Enemies.Responses;
using Assets.BEScripts.UseCases.Enemies.Dto;
using Assets.BEScripts.UseCases.Enemies.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Enemies.Controllers
{
    public class GetAllEnemyController
    {
        private readonly GetEnemiesService _getAllEnemyService;
        public GetAllEnemyController(
            GetEnemiesService getAllEnemyService
        )
        {
            _getAllEnemyService = getAllEnemyService;
        }

        public async UniTask<GetEnemiesResponseType> Execute()
        {
            GetAllEnemyResponse response = new GetAllEnemyResponse();
            GetEnemiesResponseDto dto = await _getAllEnemyService.Execute();
            return response.ToResponse(dto);
        }
    }
}