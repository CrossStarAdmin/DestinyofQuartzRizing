namespace Assets.FEScripts
{
    public static class Setting
    {
        // 全体で利用する定数
        // プレイやーの人数の設定
        public const int INIT_PLAYER_COUNT = 3;
        public const int MIN_PLAYER_COUNT = 3;
        public const int MAX_PLAYER_COUNT = 10;
        // 広告の設定
        public const string IOS_BANNER_AD_UNIT_ID = "";
        public const string IOS_INTERSTITIAL_AD_UNIT_ID = "";
        public const string IOS_REWARD_AD_UNIT_ID = "";
        public const string ANDROID_BANNER_AD_UNIT_ID = "";
        public const string ANDROID_INTERSTITIAL_AD_UNIT_ID = "";
        public const string ANDROID_REWARD_AD_UNIT_ID = "";

        // 全体で利用できる変数
        public static int playerCount;
        public static string[] playerNames;
    }
}