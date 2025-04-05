using Assets.BEScripts.Infrastructures.Repositories;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Players.Services
{
    public class CreatePlayerFromJsonService
    {
        private PlayerRepository _playerRepository;

        public CreatePlayerFromJsonService(
            PlayerRepository playerRepository
        )
        {
            _playerRepository = playerRepository;
        }

        public async UniTask Execute()
        {
            await _playerRepository.SaveFromJson();
        }
    }
}