using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.Enemies.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Enemies.Services
{
    public class GetEnemiesService
    {
        private EnemyRepository _enemyRepository;

        public GetEnemiesService(
            EnemyRepository enemyRepository
        )
        {
            _enemyRepository = enemyRepository;
        }

        public async UniTask<GetEnemiesResponseDto> Execute()
        {
            EnemyEntity[] result = await _enemyRepository.FindAll();
            return new GetEnemiesResponseDto(result);
        }
    }
}