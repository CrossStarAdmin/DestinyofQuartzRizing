using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.UserData.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.UserData.Services
{
    public class CreateUserDataService
    {
        private readonly UserDataRepository _userDataRepository;
        public CreateUserDataService(
            UserDataRepository userDataRepository
        )
        {
            _userDataRepository = userDataRepository;
        }

        public async UniTask Execute(
            CreateUserDataRequestDto dto
        )
        {
            await _userDataRepository.CreateUserData(
                dto.data
            );
        }
    }
}