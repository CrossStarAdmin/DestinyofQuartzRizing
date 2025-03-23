using Assets.BEScripts.Presentations.UserData.Requests;
using Assets.BEScripts.UseCases.UserData.Dto;
using Assets.BEScripts.UseCases.UserData.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.UserData.Controllers
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