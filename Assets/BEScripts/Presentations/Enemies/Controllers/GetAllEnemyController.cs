using Assets.BEScripts.Presentations.Enemies.Responses;
using Assets.BEScripts.UseCases.Enemies.Dto;
using Assets.BEScripts.UseCases.Enemies.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Enemies.Controllers
{
    public class GetAllEnemyController
    {
        private readonly GetAllEnemyService _getAllEnemyService;
        public GetAllEnemyController(
            GetAllEnemyService getAllEnemyService
        )
        {
            _getAllEnemyService = getAllEnemyService;
        }

        public async UniTask<GetAllEnemyResponseType> Execute()
        {
            GetAllEnemyResponse response = new GetAllEnemyResponse();
            GetAllEnemyResponseDto dto = await _getAllEnemyService.Execute();
            return response.ToResponse(dto);
        }
    }
}