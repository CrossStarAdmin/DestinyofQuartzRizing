using Assets.BEScripts.Domains.Types.Responses;

namespace Assets.FEScripts.Types.Transfer
{
    public class GetPlayersResponseTransfer
    {
        public static PlayerType[] PlayerTypesTransfer(
            GetPlayersResponseType response
        )
        {
            if (response == null) return null;
            PlayerType[] playerTypes = new PlayerType[response.list.Length];
            for (int i = 0; i < response.list.Length; i++)
            {
                playerTypes[i] = new PlayerType
                {
                    uid = response.list[i].uid,
                    name = response.list[i].name,
                    nameId = response.list[i].nameId,
                    maxHp = response.list[i].maxHp,
                    maxMp = response.list[i].maxMp,
                    attack = response.list[i].attack,
                    defense = response.list[i].defense,
                    speed = response.list[i].speed
                };
            }
            return playerTypes;
        }
    }
}