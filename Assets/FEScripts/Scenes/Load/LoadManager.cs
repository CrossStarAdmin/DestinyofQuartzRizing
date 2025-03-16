using System.Threading.Tasks;
using Assets.BEScripts;
using Assets.BEScripts.Presentations.Controllers;
using Assets.FEScripts.Abstracts;
using Assets.FEScripts.Scenes.Load;
using Cysharp.Threading.Tasks;

namespace Assets.FEScripts.Scene.Load
{
    public class LoadManager : AbstractManager<LoadEntity, LoadUI>
    {
        protected override void InitEvent()
        {

        }

        protected override async UniTask InitOriginProcess()
        {
            // ログインの処理を実行する
            await DI.loginController.Execute();
        }
    }
}