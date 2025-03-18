using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.FEScripts.Scenes.Load
{
    public class LoadEntity : MonoBehaviour
    {
        // ロードを管理するプロパティ
        // private UniTask[] _loadUniTasks;
        protected int _maxStep;
        protected int _step = 0;
        public int maxStep
        {
            get { return _maxStep; }
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