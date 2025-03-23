using System.Collections.Generic;
using Assets.BEScripts.Presentations.UserData.Requests;

namespace Assets.BEScripts.UseCases.UserData.Dto
{
    public class GetUserDataRequestDto
    {
        private readonly string _key;
        public string key
        {
            get { return _key; }
        }

        public GetUserDataRequestDto(
            GetUserDataRequest request
        )
        {
            _key = request.key;
        }
    }

    public class GetUserDataResponseDto
    {
        private readonly string _data;
        public string data
        {
            get { return _data; }
        }

        public GetUserDataResponseDto(
            string data
        )
        {
            _data = data;
        }
    }
}