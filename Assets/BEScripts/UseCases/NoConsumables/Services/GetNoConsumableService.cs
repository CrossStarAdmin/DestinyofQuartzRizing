using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.NoConsumables.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.NoConsumables.Services
{
    public class GetNoConsumablesService
    {
        private readonly NoConsumableRepository _noConsumableRepository;

        public GetNoConsumablesService(
            NoConsumableRepository noConsumableRepository
        )
        {
            _noConsumableRepository = noConsumableRepository;
        }

        public async UniTask<GetNoConsumablesResponseDto> Execute()
        {
            NoConsumableEntity[] result = await _noConsumableRepository.FindAll();
            return new GetNoConsumablesResponseDto(result);
        }
    }
}