using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.BEScripts.Infrastructures.Models.PlayFab;
using Assets.BackendScripts.Infrastructure.PlayFab.Contents;

namespace Assets.BEScripts.Infrastructures.Models.PlayFab
{
    public static class PlayFabModel
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

        // Loginから取得したい情報
        public static string GetPlayFabId()
        {
            return _login.GetPlayFabId();
        }

        // -----------------------------
        // TitleData
        // -----------------------------
        private static TitleData _titleData;
        public static TitleData titleData
        {
            get { return _titleData; }
        }
        public static void InitializeTitleData()
        {
            _titleData = new TitleData();
        }

        // -----------------------------
        // UserData
        // -----------------------------
        // UserDataクラスを取得するためのプロパティ
        private static UserData _userData;
        public static UserData userData
        {
            get { return _userData; }
        }
        public static void InitializeUserData()
        {
            _userData = new UserData();
        }

        // -----------------------------
        // CatalogList
        // -----------------------------
        // CatalogListクラスを取得するためのプロパティ
        private static CatalogList _catalogList;
        public static CatalogList catalogList
        {
            get { return _catalogList; }
        }
        public static void InitializeCatalogList()
        {
            _catalogList = new CatalogList();
        }
    }
}