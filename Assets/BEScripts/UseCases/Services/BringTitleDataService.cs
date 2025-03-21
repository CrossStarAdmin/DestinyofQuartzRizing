using Assets.BEScripts.Infrastructures.Repositories;
using Cysharp.Threading.Tasks;

namespace Assets.BEScripts.UseCases.Services
{
    public class BringTitleDataService
    {
        private readonly TitleDataRepository _titleDataRepository;
        public BringTitleDataService(
            TitleDataRepository titleDataRepository
        )
        {
            _titleDataRepository = titleDataRepository;
        }

        public async UniTask Execute()
        {
            await _titleDataRepository.GetAllTitleData();
        }
    }
}