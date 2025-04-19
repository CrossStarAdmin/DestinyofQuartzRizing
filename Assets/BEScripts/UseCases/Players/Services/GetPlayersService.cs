using Assets.BEScripts.Domains.Entities;
using Assets.BEScripts.Infrastructures.Repositories;
using Assets.BEScripts.UseCases.Players.Dto;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Players.Services
{
    public class GetPlayersService
    {
        private PlayerRepository _playerRepository;

        public GetPlayersService(
            PlayerRepository playerRepository
        )
        {
            _playerRepository = playerRepository;
        }

        public async UniTask<GetPlayersResponseDto> Execute()
        {
            PlayerEntity[] result = await _playerRepository.FindAll();
            return new GetPlayersResponseDto(result);
        }
    }
}