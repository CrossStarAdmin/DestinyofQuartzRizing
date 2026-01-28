# Copilot Instructions - Unity FEScripts アーキテクチャ

## プロジェクト概要

このプロジェクトは Unity を使用したゲーム開発プロジェクトです。FE（フロントエンド）スクリプトは、シーンごとに構造化されたアーキテクチャで設計されています。

---

## ディレクトリ構造

```
Assets/FEScripts/
├── Abstracts/              # 抽象クラス群
│   ├── AbstractManager.cs
│   ├── AbstractUI.cs
│   ├── AbstractCanvasUI.cs
│   ├── AbstractComponent.cs
│   └── AbstractComponentUI.cs
├── Scenes/                 # シーンごとのスクリプト
│   ├── Title/
│   ├── Menu/
│   ├── Battle/
│   ├── Purchase/
│   └── Load/
├── Components/             # 再利用可能なコンポーネント
│   ├── UI/                 # UIコンポーネント
│   │   ├── OriginButtonComponent.cs
│   │   └── OriginTextComponent.cs
│   ├── Elements/           # 複合要素
│   │   ├── Modal/
│   │   └── EnemyList/
│   └── CanvasUI/           # 共通CanvasUI
│       ├── HeaderCanvasUI.cs
│       └── FadeCanvasUI.cs
├── Types/                  # 型定義
├── Functions/              # ユーティリティ関数
└── Setting.cs              # グローバル設定
```

---

## アーキテクチャパターン

### 1. シーン構造（3層アーキテクチャ）

各シーンは以下の3つのクラスで構成されます：

#### **Entity（データ層）**
- **役割**: シーンで使用するデータの管理
- **継承**: `MonoBehaviour`
- **例**: `TitleEntity.cs`, `MenuEntity.cs`, `BattleEntity.cs`
- **内容**:
  - キャラクター情報
  - ステータスデータ
  - API レスポンスデータ
  - ゲーム状態

```csharp
public class MenuEntity : MonoBehaviour
{
    public List<CharacterType> characterTypes { get; }
}
```

#### **UI（表示層）**
- **役割**: 全Canvasの統合管理と表示制御
- **継承**: `AbstractUI`
- **例**: `TitleUI.cs`, `MenuUI.cs`, `BattleUI.cs`
- **内容**:
  - Canvas オブジェクトの参照管理
  - CanvasUI インスタンスの管理
  - Canvas 表示/非表示メソッド
  
**重要**: `AbstractUI` は自動的に `HeaderCanvas` と `FadeCanvas` を初期化します。

```csharp
public class MenuUI : AbstractUI
{
    protected Canvas _menuCanvas, _detailModalCanvas;
    protected MenuCanvasUI _menuCanvasUI;
    
    protected override void InitCanvas()
    {
        base.InitCanvas(); // HeaderCanvas, FadeCanvas を初期化
        _menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
    }
    
    public void DisplayMenuCanvas(bool _isDisplay)
    {
        _menuCanvas.enabled = _isDisplay;
    }
}
```

#### **Manager（制御層）**
- **役割**: シーンのロジック制御とライフサイクル管理
- **継承**: `AbstractManager<TEntity, TUI>`
- **例**: `TitleManager.cs`, `MenuManager.cs`, `BattleManager.cs`
- **ライフサイクル**:
  1. `InitEntity()` - Entity初期化（API呼び出し等）
  2. `InitUI()` - UI初期化（データバインディング）
  3. `InitEvent()` - イベント設定（ボタンアクション等）
  4. `InitOriginProcess()` - シーン固有の初期化処理
  5. `FadeFunction()` - フェードイン処理

```csharp
public class TitleManager : AbstractManager<TitleEntity, TitleUI>
{
    protected override async UniTask InitEntity()
    {
        await base.InitEntity();
        // API呼び出しやデータ初期化
    }
    
    protected override void InitUI()
    {
        base.InitUI();
        // UIへのデータ設定
    }
    
    protected override void InitEvent()
    {
        ui.playButtonCanvasUI.SetActions(new Action[] {
            () => StartGame()
        });
    }
}
```

---

### 2. CanvasUI（Canvas制御層）

各 Canvas は専用の CanvasUI クラスで制御されます。

#### **CanvasUI の基本構造**
- **継承**: `AbstractCanvasUI`
- **場所**: `Scenes/[シーン名]/CanvasUI/`
- **命名**: `[Canvas名]CanvasUI.cs`

```csharp
public class PlayerMenuCanvasUI : AbstractCanvasUI
{
    private OriginButtonComponent _startButton;
    private OriginButtonComponent _diceButton;
    
    private void Awake()
    {
        Canvas canvas = GameObject.Find("PlayerMenuCanvas").GetComponent<Canvas>();
        InitObject(canvas);
    }
    
    protected override void InitObject(Canvas _canvas)
    {
        base.InitObject(_canvas);
        // コンポーネント取得
        _startButton = _component.transform.Find("StartButton").GetComponent<OriginButtonComponent>();
        _diceButton = _component.transform.Find("DiceButton").GetComponent<OriginButtonComponent>();
    }
    
    public override void SetActions(Action[] _actions)
    {
        _startButton.InitOriginButtonComponent(_actions[0]);
        _diceButton.InitOriginButtonComponent(_actions[1]);
    }
}
```

#### **Canvas階層構造**
Unity上の Canvas オブジェクト構造:
```
[Canvas名]Canvas (Canvas)
└── Wrapper (GameObject)
    └── Component (GameObject)
        ├── Button1
        ├── Button2
        └── ...
```

`_component` は `Wrapper/Component` を参照します。

---

### 3. コンポーネント階層

#### **UI コンポーネント（基本要素）**
再利用可能な単一のUIパーツ。

**OriginButtonComponent**
- ボタンの基本実装
- クリック時のアクション実行
- ホバー/クリックアニメーション

```csharp
public void InitOriginButtonComponent(Action _action, int _soundEffectNumber = -1)
{
    _buttonAction = _action;
    // ボタンの初期化処理
}
```

**OriginTextComponent**
- テキスト表示の基本実装

#### **Elements（複合要素）**
複数のUIコンポーネントを組み合わせた要素。

**構造**:
- `[Element名]Manager.cs` - AbstractComponent を継承、ロジック担当
- `[Element名]UI.cs` - AbstractComponentUI を継承、表示担当

**Modal（モーダルダイアログ）**
```csharp
// Manager（制御）
public class ModalManager : AbstractComponent<ModalUI>
{
    public void InitializeElement(string _titleText, string _detailText)
    {
        _componentUI.SetTitleText(_titleText);
        _componentUI.SetDetailText(_detailText);
    }
}

// UI（表示）
public class ModalUI : AbstractComponentUI
{
    private TextMeshProUGUI _titleText;
    private TextMeshProUGUI _detailText;
    
    protected override void InitObject()
    {
        _titleText = transform.Find("TitleText").GetComponent<TextMeshProUGUI>();
    }
    
    public void SetTitleText(string text) { _titleText.text = text; }
}
```

---

## 抽象クラス詳細

### AbstractManager<TEntity, TUI>
- **目的**: シーン制御の共通処理
- **ジェネリック**: Entity型、UI型を指定
- **初期化フロー**: Awake → Initialize → (InitEntity → InitUI → InitEvent → InitOriginProcess → FadeFunction)
- **必須実装メソッド**:
  - `InitEntity()` - Entity初期化
  - `InitUI()` - UI初期化
  - `InitEvent()` - イベント設定
  - `InitOriginProcess()` - シーン固有処理

### AbstractUI
- **目的**: Canvas統合管理の共通処理
- **自動初期化**: HeaderCanvas、FadeCanvas
- **初期化フロー**: Awake → (InitCanvas → InitCanvasUI → SetCanvasDisplay)
- **必須実装メソッド**:
  - `InitCanvas()` - Canvas取得（base.InitCanvas()で共通Canvas初期化）
  - `InitCanvasUI()` - CanvasUI設定
  - `SetCanvasDisplay()` - 初期表示設定

### AbstractCanvasUI
- **目的**: Canvas単位の制御
- **必須実装メソッド**:
  - `InitObject(Canvas _canvas)` - コンポーネント取得
  - `SetActions(Action[] _actions)` - アクション設定
- **共通プロパティ**:
  - `_canvas` - Canvas参照
  - `_component` - Wrapper/Component GameObject参照

### AbstractComponent<TComponentUI>
- **目的**: 複合要素の制御層
- **ジェネリック**: ComponentUI型を指定
- **自動取得**: Awake時に同GameObjectの ComponentUI を取得

### AbstractComponentUI
- **目的**: 複合要素の表示層
- **必須実装メソッド**:
  - `InitObject()` - UI要素取得
  - `SetActions(Action[] _actions)` - アクション設定

---

## 命名規則

### ファイル名
- Entity: `[シーン名]Entity.cs`
- UI: `[シーン名]UI.cs`
- Manager: `[シーン名]Manager.cs`
- CanvasUI: `[Canvas名]CanvasUI.cs`
- Component Manager: `[要素名]Manager.cs`
- Component UI: `[要素名]UI.cs`

### namespace
- シーン: `Assets.FEScripts.Scenes.[シーン名]`
- シーンManager: `Assets.FEScripts.Scene.[シーン名]` （Scenesではなく単数形）
- CanvasUI: `Assets.FEScripts.Scenes.[シーン名].CanvasUI`
- Components: `Assets.FEScripts.Components.[カテゴリ]`

### クラス名
- PascalCase
- Canvas名は用途を表す（例: PlayerMenuCanvas, EnemyInfoCanvas）

---

## 新規シーン作成手順

### 1. フォルダ構造作成
```
Scenes/[シーン名]/
├── [シーン名]Entity.cs
├── [シーン名]Manager.cs
├── [シーン名]UI.cs
└── CanvasUI/
    ├── [Canvas1]CanvasUI.cs
    ├── [Canvas2]CanvasUI.cs
    └── ...
```

### 2. Entity作成
```csharp
namespace Assets.FEScripts.Scenes.[シーン名]
{
    public class [シーン名]Entity : MonoBehaviour
    {
        // データプロパティ定義
    }
}
```

### 3. UI作成
```csharp
namespace Assets.FEScripts.Scenes.[シーン名]
{
    public class [シーン名]UI : AbstractUI
    {
        // Canvas参照
        protected Canvas _canvas1, _canvas2;
        
        // CanvasUI参照（publicプロパティ）
        protected Canvas1CanvasUI _canvas1CanvasUI;
        public Canvas1CanvasUI canvas1CanvasUI { get { return _canvas1CanvasUI; } }
        
        protected override void InitCanvas()
        {
            base.InitCanvas(); // 必須
            _canvas1 = GameObject.Find("Canvas1").GetComponent<Canvas>();
        }
        
        protected override void InitCanvasUI()
        {
            base.InitCanvasUI(); // 必須
            _canvas1CanvasUI = _canvas1.GetComponent<Canvas1CanvasUI>();
        }
        
        protected override void SetCanvasDisplay()
        {
            base.SetCanvasDisplay(); // 必須
            _canvas1.enabled = true;
        }
        
        // 表示制御メソッド
        public void DisplayCanvas1(bool _isDisplay)
        {
            _canvas1.enabled = _isDisplay;
        }
    }
}
```

### 4. Manager作成
```csharp
namespace Assets.FEScripts.Scene.[シーン名]
{
    public class [シーン名]Manager : AbstractManager<[シーン名]Entity, [シーン名]UI>
    {
        protected override async UniTask InitEntity()
        {
            await base.InitEntity();
            // API呼び出し等
        }
        
        protected override void InitUI()
        {
            base.InitUI();
            // UIへのデータ設定
        }
        
        protected override void InitEvent()
        {
            // CanvasUIのSetActionsを呼び出し
            ui.canvas1CanvasUI.SetActions(new Action[] {
                () => UnityEngine.Debug.Log("Button 1"),
                () => UnityEngine.Debug.Log("Button 2")
            });
        }
        
        protected override async UniTask InitOriginProcess()
        {
            await UniTask.Delay(0);
            // シーン固有の初期化
        }
    }
}
```

### 5. CanvasUI作成（各Canvas分）
```csharp
namespace Assets.FEScripts.Scenes.[シーン名].CanvasUI
{
    public class Canvas1CanvasUI : AbstractCanvasUI
    {
        private OriginButtonComponent _button1;
        private OriginButtonComponent _button2;
        
        private void Awake()
        {
            Canvas canvas = GameObject.Find("Canvas1").GetComponent<Canvas>();
            InitObject(canvas);
        }
        
        protected override void InitObject(Canvas _canvas)
        {
            base.InitObject(_canvas);
            _button1 = _component.transform.Find("Button1").GetComponent<OriginButtonComponent>();
            _button2 = _component.transform.Find("Button2").GetComponent<OriginButtonComponent>();
        }
        
        public override void SetActions(Action[] _actions)
        {
            _button1.InitOriginButtonComponent(_actions[0]);
            _button2.InitOriginButtonComponent(_actions[1]);
        }
    }
}
```

---

## ベストプラクティス

### Manager の InitEvent
- **各CanvasUIの SetActions() を呼び出す**
- **Action配列で複数のアクションを渡す**
- **アクション不要なCanvasUIには空配列を渡す**

```csharp
protected override void InitEvent()
{
    // 複数アクション
    ui.playerMenuCanvasUI.SetActions(new Action[] {
        () => StartTurn(),
        () => RollDice()
    });
    
    // アクション不要（表示専用）
    ui.playerInfoCanvasUI.SetActions(new Action[] { });
}
```

### ログ出力
開発中は全アクションにログを出力して動作確認を容易にする。

```csharp
ui.buttonCanvasUI.SetActions(new Action[] {
    () => {
        UnityEngine.Debug.Log("Button clicked");
        ExecuteAction();
    }
});
```

### Canvas階層
Unityシーン上でのCanvas階層を守る:
```
Canvas
└── Wrapper
    └── Component
        └── [UI要素]
```

### 非同期処理
- Entity初期化では `UniTask` を使用
- API呼び出しやデータ読み込みは `await`

---

## 参照シーン例

### Title シーン
- **Entity**: プレイヤーデータ
- **Canvas**: TitleHeaderCanvas, TitleCanvas, PlayButtonCanvas, DetailModalCanvas
- **機能**: ゲーム開始、課金画面遷移

### Menu シーン
- **Entity**: キャラクターリスト
- **Canvas**: DisplayCharacterCanvas, SelectCharacterCanvas, ButtonCanvas, DetailModalCanvas
- **機能**: キャラクター選択、バトル開始

### Battle シーン
- **Entity**: プレイヤー/敵のステータス
- **Canvas**: EnemyInfoCanvas, PlayerInfoCanvas, PlayerMPCanvas, PlayerMenuCanvas, DetailModalCanvas
- **機能**: ターン制バトル、スキル選択

---

## TODO テンプレート

新規Canvas作成時は TODO コメントを含める:

```csharp
protected override void InitObject(Canvas _canvas)
{
    base.InitObject(_canvas);
    // TODO: コンポーネントの取得処理を実装
}

public override void SetActions(Action[] _actions)
{
    // TODO: アクションの設定処理を実装
}
```

---

## 注意事項

1. **base.Init系メソッドは必ず呼び出す**
   - `base.InitCanvas()` - HeaderCanvas/FadeCanvas初期化のため
   - `base.InitCanvasUI()` - 共通CanvasUI初期化のため
   - `base.InitEntity()` - Entity取得のため

2. **HeaderCanvas と FadeCanvas は AbstractUI が管理**
   - 各シーンUIで個別に定義不要
   - `ui.headerCanvasUI` は自動的に利用可能

3. **Manager の namespace は単数形**
   - `Assets.FEScripts.Scene.Title` (Scenesではない)

4. **SetActions() は必須実装**
   - アクション不要でも空配列を受け取る実装が必要

5. **Canvas名の一貫性**
   - Unity上のGameObject名とコード内の名前を一致させる
   - Find("Canvas名") で取得するため

---

## クイックリファレンス

### シーン作成プロンプト
```
FEScripts/Scenesの中のフォルダを参考に、このフォルダに[シーン名]フォルダを作成してほしいです
それぞれEntity、UI、Managerの作成及び、以下Canvas用のCanvasUIを作成してほしいです
・[Canvas1]Canvas
・[Canvas2]Canvas
・[Canvas3]Canvas
```

詳細は `.github/prompt/create-scene-structure.md` を参照。
