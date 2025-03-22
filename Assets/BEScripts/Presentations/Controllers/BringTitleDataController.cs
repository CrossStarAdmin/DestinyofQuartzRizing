using Assets.BEScripts.UseCases.TitleData.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Controllers
{
    public class BringTitleDataController
    {
        private readonly BringTitleDataService _bringTitleDataService;

        public BringTitleDataController(
            BringTitleDataService bringTitleDataService
        )
        {
            _bringTitleDataService = bringTitleDataService;
        }

        public async UniTask Execute()
        {
            await _bringTitleDataService.Execute();
        }
    }
}