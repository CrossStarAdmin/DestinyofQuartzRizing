using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.FEScripts.Functions
{
    public class GetComponentFunction
    {
        /// <summary>
        /// ゲームオブジェクトにアタッチされているComponentを取得する
        /// </summary>
        /// <typeparam name="T">取得したいComponentの型</typeparam>
        /// <param name="_address">取得したいComponentのアドレス</param>
        /// <param name="_gameObject">取得したいComponentの親GameObject。トップ層から検索したい場合はnullで</param>
        /// <param name="_isMultiple">同じ名前のComponentを作成したい場合にtrueにする</param>
        /// <returns>typeParamで指定したComponentの型を返す</returns>
        public static ComponentName Execute<ComponentName>(
            string _address,
            GameObject _gameObject = null,
            bool _isMultiple = false
        ) where ComponentName : MonoBehaviour
        {
            GameObject gameObject = _gameObject != null
                ? _gameObject.transform.Find(_address).gameObject
                : GameObject.Find(_address);
            if (gameObject != null && !_isMultiple)
                return gameObject.GetComponent<ComponentName>();
            else
                return (new GameObject(typeof(ComponentName).Name)).AddComponent<ComponentName>();
        }
    }
}
