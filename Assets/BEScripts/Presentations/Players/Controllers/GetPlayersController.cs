using Assets.BEScripts.Domains.Types.Responses;
using Assets.BEScripts.Presentations.Players.Responses;
using Assets.BEScripts.UseCases.Players.Dto;
using Assets.BEScripts.UseCases.Players.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace Assets.BEScripts.Presentations.Players.Controllers
{
    public class GetPlayersController : MonoBehaviour
    {
        private readonly GetPlayersService _getPlayersService;
        public GetPlayersController(
            GetPlayersService getPlayersService
        )
        {
            _getPlayersService = getPlayersService;
        }

        public async UniTask<GetPlayersResponseType> Execute()
        {
            GetPlayersResponse response = new GetPlayersResponse();
            GetPlayersResponseDto dto = await _getPlayersService.Execute();
            return response.ToResponse(dto);
        }
    }
}