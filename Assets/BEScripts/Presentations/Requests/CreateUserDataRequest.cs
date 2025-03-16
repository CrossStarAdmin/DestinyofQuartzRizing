using System.Collections.Generic;

namespace Assets.BEScripts.Presentations.Requests
{
    [System.Serializable]
    public class CreateUserDataRequest
    {
        public readonly Dictionary<string, string> data;
    }
}