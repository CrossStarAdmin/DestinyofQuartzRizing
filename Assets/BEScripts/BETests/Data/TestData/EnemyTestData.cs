using System;
using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Domains.Types.Json;

namespace Assets.BEScripts.BETests.Data.TestData
{
    public class EnemyTestData
    {
        private EnemyModelType _models;

        // テストデータの準備
        public EnemyTestData()
        {
            // テストデータを作成
            _models = new EnemyModelType();
            EnemyListType enemy1 = new EnemyListType();
            EnemyListType enemy2 = new EnemyListType();
            enemy1.uid = "enemy001";
            enemy1.maxHp = 100;
            enemy1.maxMp = 10;
            enemy1.attack = 20;
            enemy1.defense = 30;
            enemy1.speed = 10;
            enemy2.uid = "enemy002";
            enemy2.maxHp = 200;
            enemy2.maxMp = 20;
            enemy2.attack = 40;
            enemy2.defense = 50;
            enemy2.speed = 60;
            _models.list = new EnemyListType[2];
            _models.list[0] = enemy1;
            _models.list[1] = enemy2;
        }

        // テストデータの取得
        public EnemyModelType GetModelType()
        {
            return _models;
        }

        public EnemyListType GetListType(int index)
        {
            return _models.list[index];
        }

        public EnemyEntity[] GetEntities()
        {
            return Array.ConvertAll(_models.list, EnemyEntity.CreateFromModel);
        }

        public EnemyEntity GetEntity(int index)
        {
            return EnemyEntity.CreateFromModel(_models.list[index]);
        }

        // テストデータの確認
        public int GetCount()
        {
            return _models.list.Length;
        }
        public string GetUId(int index)
        {
            return _models.list[index].uid;
        }
        public int GetMaxHp(int index)
        {
            return _models.list[index].maxHp;
        }
        public int GetMaxMp(int index)
        {
            return _models.list[index].maxMp;
        }
        public int GetAttack(int index)
        {
            return _models.list[index].attack;
        }
        public int GetDefense(int index)
        {
            return _models.list[index].defense;
        }
        public int GetSpeed(int index)
        {
            return _models.list[index].speed;
        }
    }
}