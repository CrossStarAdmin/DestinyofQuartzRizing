using Assets.BEScripts.Presentations.Requests;
using Assets.BEScripts.UseCases.Dto;
using Assets.BEScripts.UseCases.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Controllers
{
    public class CreateUserDataController
    {
        private readonly CreateUserDataService _createUserDataService;
        public CreateUserDataController(
            CreateUserDataService createUserDataService
        )
        {
            _createUserDataService = createUserDataService;
        }

        public async UniTask Execute(
            CreateUserDataRequest request
        )
        {
            CreateUserDataRequestDto requestDto = new CreateUserDataRequestDto(request);
            await _createUserDataService.Execute(requestDto);
        }
    }
}