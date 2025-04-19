using Assets.BEScripts.Domains.Entities;

namespace Assets.BEScripts.UseCases.Enemies.Dto
{
    public class GetEnemiesResponseDto
    {
        private EnemyEntity[] _enemies;

        public GetEnemiesResponseDto(
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