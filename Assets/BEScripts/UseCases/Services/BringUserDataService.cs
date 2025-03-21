using Assets.BEScripts.Infrastructures.Repositories;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Services
{
    public class BringUserDataService
    {
        private readonly UserDataRepository _userDataRepository;
        public BringUserDataService(
            UserDataRepository userDataRepository
        )
        {
            _userDataRepository = userDataRepository;
        }

        public async UniTask Execute()
        {
            await _userDataRepository.GetAllUserData();
        }
    }
}