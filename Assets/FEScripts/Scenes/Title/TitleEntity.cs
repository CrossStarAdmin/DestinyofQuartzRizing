using UnityEngine;

namespace Assets.FEScripts.Scenes.Title
{
    public class TitleEntity : MonoBehaviour
    {
        public const int MIN_PLAYER_COUNT = 3;
        public const int MAX_PLAYER_COUNT = 10;

        private int _playerCount;
        public int playerCount
        {
            get => _playerCount;
            set
            {
                if (value < MIN_PLAYER_COUNT || value > MAX_PLAYER_COUNT)
                {
                    throw new System.ArgumentOutOfRangeException("PlayerCount must be between 0 and 4.");
                }
                _playerCount = value;
            }
        }

        private string[] _playerName;
        public string[] playerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
            }
        }
    }
}