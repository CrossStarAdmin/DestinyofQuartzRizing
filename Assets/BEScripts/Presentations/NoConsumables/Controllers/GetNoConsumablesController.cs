using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.Presentations.NoConsumables.Responses;
using Assets.BEScripts.UseCases.NoConsumables.Dto;
using Assets.BEScripts.UseCases.NoConsumables.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.NoConsumables.Controllers
{
    public class GetNoConsumablesController
    {
        private readonly GetNoConsumablesService _getNoConsumablesService;
        public GetNoConsumablesController(
            GetNoConsumablesService getNoConsumablesService
        )
        {
            _getNoConsumablesService = getNoConsumablesService;
        }

        public async UniTask<GetNoConsumablesResponseType> Execute()
        {
            GetNoConsumablesResponse response = new GetNoConsumablesResponse();
            GetNoConsumablesResponseDto dto = await _getNoConsumablesService.Execute();
            return response.ToResponse(dto);
        }
    }
}