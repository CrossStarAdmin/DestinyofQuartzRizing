using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.Presentations.Consumables.Responses;
using Assets.BEScripts.UseCases.Consumables.Dto;
using Assets.BEScripts.UseCases.Consumables.Services;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.Presentations.Consumables.Controllers
{
    public class GetConsumablesController
    {
        private readonly GetConsumablesService _getConsumablesService;
        public GetConsumablesController(
            GetConsumablesService getConsumablesService
        )
        {
            _getConsumablesService = getConsumablesService;
        }

        public async UniTask<GetConsumablesResponseType> Execute()
        {
            GetConsumablesResponse response = new GetConsumablesResponse();
            GetConsumablesResponseDto dto = await _getConsumablesService.Execute();
            return response.ToResponse(dto);
        }
    }
}