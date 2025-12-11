using Assets.BEScripts.Domains.Types.Responses;
using Assets.FEScripts.Types;
using Assets.FEScripts.Types.Transfer;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Title
{
    public class TitleEntity : MonoBehaviour
    {
        private GetPlayersResponseType _getPlayersResponseType;
        public GetPlayersResponseType getPlayersResponseType
        {
            set { _getPlayersResponseType = value; }
        }
        public PlayerType[] playerTypes
        {
            get
            {
                return GetPlayersResponseTransfer.PlayerTypesTransfer(_getPlayersResponseType);
            }
        }

        private string[] _playerNames;
        public string[] playerNames
        {
            get => _playerNames;
            set
            {
                _playerNames = value;
            }
        }
    }
}