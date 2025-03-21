using System.Collections.Generic;
using Assets.BEScripts.Presentations.Requests;

namespace Assets.BEScripts.UseCases.Dto
{
    public class GetTitleDataRequestDto
    {
        private readonly string _key;
        public string key
        {
            get { return _key; }
        }

        public GetTitleDataRequestDto(
            GetTitleDataRequest request
        )
        {
            _key = request.key;
        }
    }

    public class GetTitleDataResponseDto
    {
        private readonly string _data;
        public string data
        {
            get { return _data; }
        }

        public GetTitleDataResponseDto(
            string data
        )
        {
            _data = data;
        }
    }
}