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
        protected string _version;
        public int step
        {
            get { return _step; }
        }
        public int maxStep
        {
            get { return _maxStep; }
            set { _maxStep = value; }
        }
        public string version
        {
            get { return _version; }
            set { _version = value; }
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