using System;
using System.Collections.Generic;
using Assets.FEScripts.Types;
using UnityEngine;

namespace Assets.FEScripts
{
    public static class Setting
    {
        // 全体で利用する定数
        // 設定できるキャラクター一覧
        public static List<CharacterType> CHARACTER_LIST = new List<CharacterType>()
        {
            new CharacterType() { id = 1, characterName = "Warrior", abbreviationName = "Warrior" },
            new CharacterType() { id = 2, characterName = "Wizard", abbreviationName = "Wizard" },
            new CharacterType() { id = 3, characterName = "Priest", abbreviationName = "Priest" },
            new CharacterType() { id = 4, characterName = "Monk", abbreviationName = "Monk" },
            new CharacterType() { id = 5, characterName = "Merchant", abbreviationName = "Merchant" },
            new CharacterType() { id = 6, characterName = "Fortune Teller", abbreviationName = "FortuneTeller" },
        };
        // 設定できる色一覧
        public static List<Color32> COLOR_LIST = new List<Color32>()
        {
            new Color32(154,  54,  54, 255),  // 赤
            new Color32(178, 147,  56, 255),  // 黄
            new Color32( 71, 136, 240, 255),  // 明るい青
            new Color32(139,  79, 251, 255),  // 紫
            new Color32( 73,  42,  42, 255),  // 暗い赤
            new Color32( 42,  42,  42, 255),  // 灰
            new Color32( 28,  42,  42, 255),  // 黒
            new Color32(255, 255, 255, 255),  // 白
        };
        // 広告の設定
        public const string IOS_BANNER_AD_UNIT_ID = "";
        public const string IOS_INTERSTITIAL_AD_UNIT_ID = "";
        public const string IOS_REWARD_AD_UNIT_ID = "";
        public const string ANDROID_BANNER_AD_UNIT_ID = "";
        public const string ANDROID_INTERSTITIAL_AD_UNIT_ID = "";
        public const string ANDROID_REWARD_AD_UNIT_ID = "";

        // 変数
        public static int initHP = 25;
        public static int initMP = 10;
        public static int initFirstTension = 0;
        public static int initSecondTension = 2;

        public static CharacterType selectedPlayerCharacter = CHARACTER_LIST[1];
        public static CharacterType selectedEnemyCharacter = CHARACTER_LIST[1];

        // 各種機能
        public static Color32 GetColor(string colorName, int opacity)
        {
            Color32 color = colorName switch
            {
                "red" => COLOR_LIST[0],
                "yellow" => COLOR_LIST[1],
                "lightBlue" => COLOR_LIST[2],
                "purple" => COLOR_LIST[3],
                "darkRed" => COLOR_LIST[4],
                "gray" => COLOR_LIST[5],
                "black" => COLOR_LIST[6],
                "white" => COLOR_LIST[7],
                _ => COLOR_LIST[6],
            };
            color.a = (byte)opacity;
            return color;
        }
    }
}