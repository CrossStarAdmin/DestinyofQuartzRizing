using UnityEngine;

namespace Assets.FEScripts.Scenes.Load
{
    public class LoadEntity : MonoBehaviour
    {
        // ロードを管理するプロパティ
        protected int _maxStep;
        protected int _step = 0;
        public int maxStep
        {
            set { _maxStep = value; }
        }

        public void AddStep()
        {
            _step++;
        }
        public float percent
        {
            get { return _step * (100 / _maxStep); }
        }
    }
}