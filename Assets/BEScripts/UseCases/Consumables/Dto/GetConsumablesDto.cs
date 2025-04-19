using Assets.BEScripts.Domains.Entities;

namespace Assets.BEScripts.UseCases.Consumables.Dto
{
    public class GetConsumablesResponseDto
    {
        private ConsumableEntity[] _consumables;

        public GetConsumablesResponseDto(
            ConsumableEntity[] consumables
        )
        {
            _consumables = consumables;
        }

        public ConsumableEntity[] consumables
        {
            get { return _consumables; }
        }
    }
}