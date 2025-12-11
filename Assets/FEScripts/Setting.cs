using System;
using System.Collections.Generic;
using Assets.FEScripts.Types;

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
        // 広告の設定
        public const string IOS_BANNER_AD_UNIT_ID = "";
        public const string IOS_INTERSTITIAL_AD_UNIT_ID = "";
        public const string IOS_REWARD_AD_UNIT_ID = "";
        public const string ANDROID_BANNER_AD_UNIT_ID = "";
        public const string ANDROID_INTERSTITIAL_AD_UNIT_ID = "";
        public const string ANDROID_REWARD_AD_UNIT_ID = "";

        // 変数
        public static CharacterType selectedPlayerCharacter = CHARACTER_LIST[0];
        public static CharacterType selectedEnemyCharacter = CHARACTER_LIST[0];
    }
}