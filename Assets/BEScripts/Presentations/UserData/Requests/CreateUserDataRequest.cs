using System.Collections.Generic;

namespace Assets.BEScripts.Presentations.UserData.Requests
{
    [System.Serializable]
    public class CreateUserDataRequest
    {
        public Dictionary<string, string> data;
    }
}