using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.UserData.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.UserData.Services
{
    public class GetUserDataService
    {
        private readonly UserDataRepository _userDataRepository;
        public GetUserDataService(
            UserDataRepository userDataRepository
        )
        {
            _userDataRepository = userDataRepository;
        }

        public async UniTask<GetUserDataResponseDto> Execute(
            GetUserDataRequestDto dto
        )
        {
            string data = await _userDataRepository.GetUserData(
                dto.key
            );
            return new GetUserDataResponseDto(data);
        }
    }
}