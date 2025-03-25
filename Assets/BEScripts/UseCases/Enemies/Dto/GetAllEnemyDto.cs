using Assets.BEScripts.Domains.Entities;

namespace Assets.BEScripts.UseCases.Enemies.Dto
{
    public class GetAllEnemyResponseDto
    {
        private EnemyEntity[] _enemies;

        public GetAllEnemyResponseDto(
            EnemyEntity[] enemies
        )
        {
            _enemies = enemies;
        }

        public EnemyEntity[] enemies
        {
            get { return _enemies; }
        }
    }
}