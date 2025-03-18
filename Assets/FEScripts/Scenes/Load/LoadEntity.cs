using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Load
{
    public class LoadEntity : MonoBehaviour
    {
        // ロードを管理するプロパティ
        private UniTask[] _loadUniTasks;
        protected int _step = 0;
        public UniTask[] loadUniTasks
        {
            get { return _loadUniTasks; }
            set { _loadUniTasks = value; }
        }

        public void AddStep()
        {
            _step++;
        }
        public float percent
        {
            get { return _step * (100 / _loadUniTasks.Length); }
        }
    }
}