using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Services
{
    public class GetTitleDataService
    {
        private readonly TitleDataRepository _userDataRepository;
        public GetTitleDataService(
            TitleDataRepository userDataRepository
        )
        {
            _userDataRepository = userDataRepository;
        }

        public async UniTask<GetTitleDataResponseDto> Execute(
            GetTitleDataRequestDto dto
        )
        {
            string data = await _userDataRepository.GetTitleData(
                dto.key
            );
            return new GetTitleDataResponseDto(data);
        }
    }
}