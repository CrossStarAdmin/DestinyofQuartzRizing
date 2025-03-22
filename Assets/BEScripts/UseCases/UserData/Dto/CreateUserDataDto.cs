using System.Collections.Generic;
using Assets.BEScripts.Presentations.Requests;

namespace Assets.BEScripts.UseCases.UserData.Dto
{
    public class CreateUserDataRequestDto
    {
        private readonly Dictionary<string, string> _data;
        public Dictionary<string, string> data
        {
            get { return _data; }
        }

        public CreateUserDataRequestDto(
            CreateUserDataRequest request
        )
        {
            _data = request.data;
        }
    }
}