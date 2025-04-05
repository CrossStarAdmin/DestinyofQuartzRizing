using Assets.BEScripts.UseCases.Players.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Players.Controllers
{
    public class CreatePlayerFromJsonController
    {
        private CreatePlayerFromJsonService _createPlayerFromJsonService;
        public CreatePlayerFromJsonController(
            CreatePlayerFromJsonService createPlayerFromJsonService
        )
        {
            _createPlayerFromJsonService = createPlayerFromJsonService;
        }

        public async UniTask Execute()
        {
            await _createPlayerFromJsonService.Execute();
        }
    }
}