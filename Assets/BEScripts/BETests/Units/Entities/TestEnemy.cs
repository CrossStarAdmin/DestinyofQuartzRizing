using Assets.BEScripts.BETests.Data.TestData;
using Assets.BEScripts.Domains.Entities;
using NUnit.Framework;

namespace Assets.BEScripts.BETests.Units.Entities
{
    public class TestEnemy
    {
        private EnemyTestData _enemyTestData;
        public TestEnemy()
        {
            _enemyTestData = new EnemyTestData();
        }

        [Test]
        public void CreateFromModelでEntityが正常にできる()
        {
            EnemyEntity enemy = EnemyEntity.CreateFromModel(_enemyTestData.GetListType(0));
            Assert.AreEqual(_enemyTestData.GetUId(0), enemy.uid);
            Assert.AreEqual(_enemyTestData.GetMaxHp(0), enemy.maxHp);
            Assert.AreEqual(_enemyTestData.GetMaxMp(0), enemy.maxMp);
            Assert.AreEqual(_enemyTestData.GetAttack(0), enemy.attack);
            Assert.AreEqual(_enemyTestData.GetDefense(0), enemy.defense);
            Assert.AreEqual(_enemyTestData.GetSpeed(0), enemy.speed);
        }
    }
}