using System.Collections.Generic;
using Assets.BEScripts;
using Assets.BEScripts.Presentations.Enemies.Controllers;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Menu;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.FEScripts.Scene.Menu
{
    public class MenuManager : AbstractManager<MenuEntity, MenuUI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            entity.getEnemiesResponseType = await DI.getEnemiesController.Execute();
        }
        protected override void InitEvent()
        {

        }

        protected override async UniTask InitOriginProcess()
        {
            await UniTask.Delay(0);
        }
    }
}