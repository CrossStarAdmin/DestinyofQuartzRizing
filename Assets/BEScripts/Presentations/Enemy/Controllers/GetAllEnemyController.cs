using Assets.BEScripts.Presentations.Enemy.Responses;
using Assets.BEScripts.UseCases.Enemy.Dto;
using Assets.BEScripts.UseCases.Enemy.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Enemy.Controllers
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