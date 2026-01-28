# シーン構造作成プロンプト

## 概要
Unity用のシーン構造を一括で作成するためのプロンプトテンプレートです。

## 使用方法

以下のプロンプトをAIに送信してください：

```
FEScripts/Scenesの中のフォルダを参考に、このフォルダに[シーン名]フォルダを作成してほしいです
それぞれEntity、UI、Managerの作成及び、以下Canvas用のCanvasUIを作成してほしいです
・[Canvas名1]Canvas
・[Canvas名2]Canvas
・[Canvas名3]Canvas
```

## テンプレート例

### Battleシーンの場合

```
FEScripts/Scenesの中のフォルダを参考に、このフォルダにBattleフォルダを作成してほしいです
それぞれEntity、UI、Managerの作成及び、以下Canvas用のCanvasUIを作成してほしいです
・EnemyInfoCanvas
・PlayerMPCanvas
・PlayerMenuCanvas
・PlayerInfoCanvas
・DetailModalCanvas
```

### Shopシーンの場合

```
FEScripts/Scenesの中のフォルダを参考に、このフォルダにShopフォルダを作成してほしいです
それぞれEntity、UI、Managerの作成及び、以下Canvas用のCanvasUIを作成してほしいです
・ShopItemListCanvas
・ShopCartCanvas
・ShopCategoryCanvas
・DetailModalCanvas
```

## 作成されるファイル構造

```
FEScripts/Scenes/[シーン名]/
├── [シーン名]Entity.cs      # データ管理クラス
├── [シーン名]UI.cs           # UI統合管理クラス
├── [シーン名]Manager.cs      # ロジック制御クラス
└── CanvasUI/
    ├── [Canvas名1]CanvasUI.cs
    ├── [Canvas名2]CanvasUI.cs
    └── [Canvas名3]CanvasUI.cs
```

## 各ファイルの役割

### Entity
- シーンで使用するデータの管理
- キャラクター情報、ステータス等のエンティティを保持

### UI
- すべてのCanvasUIを統合管理
- Canvas表示/非表示の制御メソッド提供
- AbstractUIを継承（HeaderCanvas、FadeCanvasは自動で継承）

### Manager
- シーンのロジック制御
- Entity・UIの初期化
- イベント設定
- AbstractManagerを継承

### CanvasUI
- 各Canvas単位の制御クラス
- AbstractCanvasUIを継承
- SetActions()でアクション設定
- TODO付きテンプレートとして生成

## 命名規則

- クラス名: PascalCase
- Canvas名: [用途]Canvas（例: EnemyInfoCanvas）
- ファイル名: クラス名.cs
- namespace: Assets.FEScripts.Scenes.[シーン名]
- CanvasUI namespace: Assets.FEScripts.Scenes.[シーン名].CanvasUI

## 注意事項

- AbstractUI、AbstractManager、AbstractCanvasUIを継承する設計
- DetailModalCanvasはモーダル表示用の共通Canvas
- HeaderCanvasとFadeCanvasはAbstractUIで自動的に初期化される
- 各CanvasUIにはTODOコメントが含まれる
