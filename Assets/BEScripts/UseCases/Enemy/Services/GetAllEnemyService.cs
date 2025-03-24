using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.Enemy.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Enemy.Services
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

        public async UniTask<GetAllEnemyDto> Execute()
        {
            EnemyEntity[] result = await _enemyRepository.FindAll();
            return new GetAllEnemyDto(result);
        }
    }
}