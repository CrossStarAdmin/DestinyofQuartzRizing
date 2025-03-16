using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.FEScripts.Abstracts
{
    public abstract class AbstractManager<OriginEntity, OriginUI>
        : MonoBehaviour
        where OriginEntity : MonoBehaviour
        where OriginUI : MonoBehaviour
    {
        protected OriginEntity entity;
        protected OriginUI ui;
        private void Awake()
        {
            Initialize().Forget((e) => Debug.LogError(e));
        }

        private async UniTask Initialize()
        {
            await InitEntity();
            InitUI();
            InitEvent();
            await InitOriginProcess();
        }

        /// <summary>
        /// Entityの初期値を設定する
        /// </summary>
        /// <returns></returns>
        protected virtual UniTask InitEntity()
        {
            // ログ
            Debug.Log("Init Entity");
            // GameSceneから引き継いだEntityを設定する
            entity = GameObject.FindObjectOfType<OriginEntity>();
            return UniTask.CompletedTask;
        }

        /// <summary>
        /// UIの初期値を設定する
        /// </summary>
        /// <returns></returns>
        protected virtual void InitUI()
        {
            Debug.Log("Init UI");
            // GameSceneから引き継いだUIを設定する
            ui = GameObject.FindObjectOfType<OriginUI>();
        }

        /// <summary>
        /// イベントの初期値を設定する
        /// </summary>
        /// <returns></returns>
        protected abstract void InitEvent();

        /// <summary>
        /// オリジナルの処理を実行する
        /// </summary>
        /// <returns></returns>
        protected abstract UniTask InitOriginProcess();
    }
}