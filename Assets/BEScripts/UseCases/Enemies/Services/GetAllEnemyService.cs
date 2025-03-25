using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.Enemies.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Enemies.Services
{
    public class GetAllEnemyService
    {
        private EnemyRepository _enemyRepository;

        public GetAllEnemyService(
            EnemyRepository enemyRepository
        )
        {
            _enemyRepository = enemyRepository;
        }

        public async UniTask<GetAllEnemyResponseDto> Execute()
        {
            EnemyEntity[] result = await _enemyRepository.FindAll();
            return new GetAllEnemyResponseDto(result);
        }
    }
}