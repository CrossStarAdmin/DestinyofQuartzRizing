using Assets.BEScripts.Domains.Types.Responses;
using Assets.FEScripts.Types;
using Assets.FEScripts.Types.Transfer;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Menu
{
    public class MenuEntity : MonoBehaviour
    {
        private GetEnemiesResponseType _getEnemiesResponseType;
        public GetEnemiesResponseType getEnemiesResponseType
        {
            set { _getEnemiesResponseType = value; }
        }
        public EnemyType[] enemyTypes
        {
            get
            {
                return GetEnemiesResponseTransfer.EnemyTypesTransfer(_getEnemiesResponseType);
            }
        }
    }
}