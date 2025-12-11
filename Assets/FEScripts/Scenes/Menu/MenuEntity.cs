using System.Collections.Generic;
using Assets.BEScripts.Domains.Types.Responses;
using Assets.FEScripts.Types;
using Assets.FEScripts.Types.Transfer;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Menu
{
    public class MenuEntity : MonoBehaviour
    {
        public List<CharacterType> characterTypes
        {
            get
            {
                return Setting.CHARACTER_LIST;
            }
        }
    }
}