using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

namespace Assets.BEScripts.Domains.Abstracts
{
    public class AbstractPlayFab
    {
        protected bool _isProcess = false;
        protected bool _isSuccess = false;

        public bool isProcess
        {
            get { return _isProcess; }
        }
        public bool isSuccess
        {
            get { return _isSuccess; }
        }

        protected void BeforeFunction()
        {
            _isProcess = true;
            _isSuccess = true;
        }
        protected void SuccessFunction()
        {
            _isProcess = false;
            _isSuccess = true;
        }
        protected void FailedFunction(PlayFabError _error)
        {
            _isProcess = false;
            _isSuccess = false;
            Debug.LogError(_error.GenerateErrorReport());
        }
    }
}