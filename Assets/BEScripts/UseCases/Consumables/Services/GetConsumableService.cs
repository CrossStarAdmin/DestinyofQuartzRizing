using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.Consumables.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Consumables.Services
{
    public class GetConsumablesService
    {
        private readonly ConsumableRepository _consumableRepository;

        public GetConsumablesService(
            ConsumableRepository consumableRepository
        )
        {
            _consumableRepository = consumableRepository;
        }

        public async UniTask<GetConsumablesResponseDto> Execute()
        {
            ConsumableEntity[] result = await _consumableRepository.FindAll();
            return new GetConsumablesResponseDto(result);
        }
    }
}