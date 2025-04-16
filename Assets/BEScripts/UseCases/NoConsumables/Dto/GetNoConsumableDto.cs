using Assets.BEScripts.Domains.Entities;

namespace Assets.BEScripts.UseCases.NoConsumables.Dto
{
    public class GetNoConsumablesResponseDto
    {
        private NoConsumableEntity[] _noConsumables;

        public GetNoConsumablesResponseDto(
            NoConsumableEntity[] noConsumables
        )
        {
            _noConsumables = noConsumables;
        }

        public NoConsumableEntity[] noConsumables
        {
            get { return _noConsumables; }
        }
    }
}