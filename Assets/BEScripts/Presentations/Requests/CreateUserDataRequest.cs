using System.Collections.Generic;

namespace Assets.BEScripts.Presentations.Requests
{
    [System.Serializable]
    public class CreateUserDataRequest
    {
        public Dictionary<string, string> data;
    }
}