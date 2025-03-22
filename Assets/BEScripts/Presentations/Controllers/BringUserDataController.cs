using Assets.BEScripts.UseCases.UserData.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Controllers
{
    public class BringUserDataController
    {
        private readonly BringUserDataService _bringUserDataService;

        public BringUserDataController(
            BringUserDataService bringUserDataService
        )
        {
            _bringUserDataService = bringUserDataService;
        }

        public async UniTask Execute()
        {
            await _bringUserDataService.Execute();
        }
    }
}