using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.BEScripts.Infrastructures.Models.PlayFab;

namespace Assets.BEScripts.Infrastructures.Models.PlayFab
{
    public static class PlayFabController
    {
        // -----------------------------
        // Login
        // -----------------------------
        // Loginクラスを取得するためのプロパティ
        private static Login _login;
        public static Login login
        {
            get { return _login; }
        }

        // Loginクラスを初期化する
        public static void InitializeLogin()
        {
            _login = new Login();
        }
    }
}