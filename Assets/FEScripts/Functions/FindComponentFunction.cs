using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.FEScripts.Functions
{
    public class FindComponentFunction
    {
        /// <summary>
        /// GameObjectにアタッチされてるGameObjectがあるかどうかを確認する
        /// </summary>
        /// <param name="_address">取得したいGameObjectのアドレス</param>
        /// <param name="_gameObject">親GameObject。トップ層から検索したい場合はnullで</param>
        /// <returns>ある場合はtrue、ない場合はfalse</returns>
        public static bool Execute(
            string _address,
            GameObject _gameObject = null
        )
        {
            return _gameObject != null ? _gameObject.transform.Find(_address) : GameObject.Find(_address);
        }
    }
}
