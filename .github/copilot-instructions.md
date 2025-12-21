# Copilot Instructions

このドキュメントは Unity プロジェクト（FEScripts/BEScripts）の開発における指針をまとめたものです。

---

## 📚 ドキュメント構成

### 1. FEScript アーキテクチャ詳細
**ファイル**: [copilot-instructions-fescript-architecture.md](./copilot-instructions-fescript-architecture.md)

**内容**:
- プロジェクト概要とディレクトリ構造
- アーキテクチャパターン（Entity/UI/Manager/CanvasUI）
- 抽象クラス詳細（AbstractManager, AbstractUI, AbstractCanvasUI等）
- 命名規則
- 新規シーン作成手順（5ステップ）
- ベストプラクティス
- 参照シーン例（Title/Menu/Battle）

**用途**: 新規シーン作成、アーキテクチャ理解、コード構造の参照

### 2. BEScript アーキテクチャ詳細
**ファイル**: [copilot-instructions-bescript-architecture.md](./copilot-instructions-bescript-architecture.md)

**内容**:
- プロジェクト概要とディレクトリ構造
- アーキテクチャパターン（Repository/Service/Controller）
- API設計パターン
- データモデル設計
- テストパターン

**用途**: バックエンドAPI開発、データ処理ロジック、テスト作成

---

## 🔀 Git / GitHub ルール

### プルリクエストのコミットメッセージ

#### 基本ルール
1. **日本語で記述する**
2. **gitmoji を使用する** - 該当するアイコンを先頭に付ける
3. **簡潔にまとめる** - 1行で変更内容を表現

#### gitmoji 使用例
```
✨ 新機能追加: BattleシーンのPlayerMenuCanvas実装
🐛 バグ修正: SetActionsの配列インデックスエラー修正
♻️ リファクタリング: TitleManagerのInitEvent整理
📝 ドキュメント更新: copilot-instructionsにBEScript追記
🎨 コード整形: PlayerEntityのインデント修正
🔥 不要コード削除: 未使用のCanvasUI削除
🚀 パフォーマンス改善: Repository初期化処理最適化
✅ テスト追加: PlayerRepositoryのユニットテスト
🔧 設定変更: DI.csにItemController追加
🚨 警告修正: null参照警告の解消
```

#### 主要gitmoji一覧
| gitmoji | 用途 | 例 |
|---------|------|-----|
| ✨ | 新機能追加 | ✨ MenuシーンにDetailModalCanvas追加 |
| 🐛 | バグ修正 | 🐛 NullReferenceException修正 |
| ♻️ | リファクタリング | ♻️ AbstractManager共通処理抽出 |
| 📝 | ドキュメント | 📝 READMEにセットアップ手順追加 |
| 🎨 | コード整形 | 🎨 命名規則に従ってリネーム |
| 🔥 | コード削除 | 🔥 デバッグ用ログ削除 |
| 🚀 | パフォーマンス | 🚀 UniTask.WhenAllで並列処理化 |
| ✅ | テスト | ✅ PlayerEntityのテスト追加 |
| 🔧 | 設定ファイル | 🔧 DI.cs更新 |
| 🚨 | 警告/エラー修正 | 🚨 コンパイル警告修正 |

### ブランチ戦略
- `main` - 本番環境
- `develop` - 開発環境
- `feature/[バージョン]/[機能名]` - 機能開発ブランチ（例: feature/1.0.0/UpdateBattleScene）

### プルリクエスト作成時
1. **日本語でタイトルと説明を記述**
2. **変更内容を簡潔に箇条書き**
3. **関連Issueがあればリンク**

---

## 🎯 コーディング規約

### 基本方針
- **可読性重視**: 変数名・メソッド名は用途を明確に
- **責務の分離**: 
  - FEScript: Entity（データ）、UI（表示）、Manager（制御）を明確に分離
  - BEScript: Domain（エンティティ）、UseCase（ビジネスロジック）、Infrastructure（データアクセス）、Presentation（API）を明確に分離
- **base呼び出し必須**: すべての `Init` 系メソッドで `base.Init***()` を先頭で呼び出す
- **TODO活用**: 未実装箇所には必ず `// TODO:` コメントを記載
- **非同期処理**: `UniTask` を使用し、`async/await` パターンを徹底

### 命名規則

#### FEScript
```csharp
// クラス名: PascalCase
public class TitleManager : AbstractManager<TitleEntity, TitleUI>

// プライベートフィールド: _camelCase（アンダースコア接頭辞）
private Canvas _menuCanvas;
private OriginButtonComponent _startButton;

// プロパティ: camelCase（アンダースコアなし）
public Canvas1CanvasUI canvas1CanvasUI { get { return _canvas1CanvasUI; } }

// メソッド: PascalCase
public void DisplayMenuCanvas(bool _isDisplay)

// パラメータ: _camelCase（アンダースコア接頭辞）
public void InitializeElement(string _titleText, string _detailText)
```

#### BEScript
```csharp
// クラス名: PascalCase + 役割サフィックス
public class PlayerEntity { }
public class PlayerRepository { }
public class GetPlayersService { }
public class GetPlayersController : MonoBehaviour { }

// プライベートフィールド: _camelCase（アンダースコア接頭辞）
private PlayerRepository _playerRepository;
private PlayerModelType _model;

// プロパティ: camelCase（アンダースコアなし、get専用）
public string uid { get { return _uid; } }

// メソッド: PascalCase（動詞で始める）
public async UniTask<PlayerEntity[]> FindAll()
public async UniTask Save(PlayerEntity player)
```

### namespace 規則

#### FEScript
```csharp
// シーン（Entity, UI, CanvasUI）
namespace Assets.FEScripts.Scenes.Title

// Manager（単数形）
namespace Assets.FEScripts.Scene.Title

// コンポーネント
namespace Assets.FEScripts.Components.UI
namespace Assets.FEScripts.Components.Elements.Modal
```

#### BEScript
```csharp
// Domain層
namespace Assets.BEScripts.Domains.Entities
namespace Assets.BEScripts.Domains.Types

// UseCase層（複数形）
namespace Assets.BEScripts.UseCases.Players.Services
namespace Assets.BEScripts.UseCases.Players.Dto

// Infrastructure層
namespace Assets.BEScripts.Infrastructures.Repositories
namespace Assets.BEScripts.Infrastructures.Models.PlayFab

// Presentation層（複数形）
namespace Assets.BEScripts.Presentations.Players.Controllers
namespace Assets.BEScripts.Presentations.Players.Responses
```

---

## 🔧 コード記述ガイド

### FEScript パターン

#### 1. Manager の InitEvent パターン
```csharp
protected override void InitEvent()
{
    // 各CanvasUIのSetActionsを呼び出し
    // 開発中は必ずログを出力
    
    // 複数アクションの場合
    ui.playerMenuCanvasUI.SetActions(new Action[] {
        () => {
            UnityEngine.Debug.Log("[PlayerMenuCanvas] StartTurn clicked");
            StartTurn();
        },
        () => {
            UnityEngine.Debug.Log("[PlayerMenuCanvas] RollDice clicked");
            RollDice();
        }
    });
    
    // 表示専用Canvas（アクションなし）
    ui.playerInfoCanvasUI.SetActions(new Action[] { });
}
```

#### 2. CanvasUI の SetActions パターン
```csharp
public override void SetActions(Action[] _actions)
{
    // アクション配列の要素数 = ボタン数
    // 配列インデックスとボタンの対応を明確に
    
    if (_actions.Length >= 1)
        _button1.InitOriginButtonComponent(_actions[0]);
    
    if (_actions.Length >= 2)
        _button2.InitOriginButtonComponent(_actions[1]);
    
    // 効果音指定の場合
    if (_actions.Length >= 3)
        _button3.InitOriginButtonComponent(_actions[2], soundEffectNumber: 1);
}
```

#### 3. UI の Display メソッドパターン
```csharp
// Canvas表示制御は各UIクラスにpublicメソッドとして実装
public void DisplayMenuCanvas(bool _isDisplay)
{
    _menuCanvas.enabled = _isDisplay;
}

// Managerから呼び出し
ui.DisplayMenuCanvas(true);
```

#### 4. Entity のデータプロパティパターン
```csharp
public class BattleEntity : MonoBehaviour
{
    // プロパティはget専用（外部からの書き込み禁止）
    public CharacterType playerCharacter { get; private set; }
    public CharacterType enemyCharacter { get; private set; }
    
    // セッター用メソッドを別途定義
    public void SetPlayerCharacter(CharacterType _character)
    {
        playerCharacter = _character;
    }
}
```

#### 5. 非同期処理パターン
```csharp
protected override async UniTask InitEntity()
{
    await base.InitEntity();
    
    // API呼び出し
    var response = await ApiClient.GetCharacterData();
    entity.SetCharacterData(response);
    
    // 複数API並列実行
    await UniTask.WhenAll(
        ApiClient.GetPlayerData(),
        ApiClient.GetEnemyData()
    );
}
```

---

### BEScript パターン

#### 1. Entity の不変オブジェクトパターン
```csharp
public class PlayerEntity
{
    // プライベートフィールド（変更不可）
    private string _uid;
    private string _name;
    private int _maxHp;

    // コンストラクタで初期化
    public PlayerEntity(string uid, string name, int maxHp)
    {
        _uid = uid;
        _name = name;
        _maxHp = maxHp;
    }

    // ファクトリメソッド（Model → Entity変換）
    public static PlayerEntity CreateFromModel(PlayerListType _param)
    {
        return new PlayerEntity(_param.uid, _param.name, _param.maxHp);
    }

    // Get専用プロパティ
    public string uid { get { return _uid; } }
    public string name { get { return _name; } }
    public int maxHp { get { return _maxHp; } }
}
```

#### 2. Repository のCRUDパターン
```csharp
public class PlayerRepository
{
    private PlayerModelType _model;

    // 初期化（PlayFabからデータ取得）
    public async UniTask Initialize()
    {
        string data = await PlayFabModel.userData.GetUserData(Setting.PLAYER_DATA_KEY);
        if (string.IsNullOrEmpty(data))
        {
            _model = new PlayerModelType { list = new PlayerListType[0] };
        }
        else
        {
            _model = JsonConvert.DeserializeObject<PlayerModelType>(data);
        }
    }

    // 全件取得
    public async UniTask<PlayerEntity[]> FindAll()
    {
        if (_model == null) await Initialize();
        return Array.ConvertAll(_model.list, PlayerEntity.CreateFromModel);
    }

    // UID指定取得
    public async UniTask<PlayerEntity> FindByUid(string uid)
    {
        if (_model == null) await Initialize();
        PlayerListType modelParam = Array.Find(_model.list, _ => _.uid == uid);
        if (modelParam == null)
            throw new Exception($"Player with UID {uid} not found.");
        return PlayerEntity.CreateFromModel(modelParam);
    }

    // 保存
    public async UniTask Save(PlayerEntity player)
    {
        if (_model == null) await Initialize();
        
        int index = Array.FindIndex(_model.list, _ => _.uid == player.uid);
        if (index < 0)
            throw new Exception($"Player with UID {player.uid} not found.");

        // モデル更新
        _model.list[index] = new PlayerListType
        {
            uid = player.uid,
            name = player.name,
            maxHp = player.maxHp
        };

        // PlayFabに保存
        string json = JsonConvert.SerializeObject(_model);
        await PlayFabModel.userData.UpdateUserData(Setting.PLAYER_DATA_KEY, json);
    }
}
```

#### 3. Service のビジネスロジックパターン
```csharp
public class GetPlayersService
{
    private PlayerRepository _playerRepository;

    // コンストラクタでRepository注入
    public GetPlayersService(PlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    // ビジネスロジック実行
    public async UniTask<GetPlayersResponseDto> Execute()
    {
        // Repositoryからデータ取得
        PlayerEntity[] result = await _playerRepository.FindAll();
        
        // ビジネスロジック適用（フィルタリング、ソート等）
        // ...
        
        // Dtoに変換して返却
        return new GetPlayersResponseDto(result);
    }
}
```

#### 4. Controller のAPIエンドポイントパターン
```csharp
public class GetPlayersController : MonoBehaviour
{
    private readonly GetPlayersService _getPlayersService;

    // コンストラクタでService注入
    public GetPlayersController(GetPlayersService getPlayersService)
    {
        _getPlayersService = getPlayersService;
    }

    // FEScriptsから呼ばれるメソッド
    public async UniTask<GetPlayersResponseType> Execute()
    {
        GetPlayersResponse response = new GetPlayersResponse();
        GetPlayersResponseDto dto = await _getPlayersService.Execute();
        return response.ToResponse(dto);
    }
}
```

#### 5. DI（依存性注入）パターン
```csharp
public static class DI
{
    // Service初期化（Repositoryを注入）
    public static GetPlayersService getPlayersService = new GetPlayersService(
        new PlayerRepository()
    );

    // Controller初期化（Serviceを注入）
    public static GetPlayersController getPlayersController = new GetPlayersController(
        getPlayersService
    );
}

// FEScriptsからの呼び出し
GetPlayersResponseType response = await DI.getPlayersController.Execute();
```

---

## ⚠️ 重要な注意事項

### FEScript

#### 1. base.Init***() の必須呼び出し
```csharp
// ❌NG: base呼び出しなし
protected override void InitCanvas()
{
    _menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
}

// ✅OK: 必ずbase.InitCanvas()を先頭で呼び出し
protected override void InitCanvas()
{
    base.InitCanvas(); // HeaderCanvas, FadeCanvasを自動初期化
    _menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
}
```

#### 2. Canvas GameObject 名の一貫性
```csharp
// Unity シーン上のGameObject名
PlayerMenuCanvas

// コード内でのFind指定（完全一致必須）
Canvas canvas = GameObject.Find("PlayerMenuCanvas").GetComponent<Canvas>();

// クラス名
public class PlayerMenuCanvasUI : AbstractCanvasUI
```

#### 3. SetActions の配列要素数
```csharp
// ❌NG: ボタン2つなのに3つのアクション
ui.playerMenuCanvasUI.SetActions(new Action[] {
    () => StartTurn(),
    () => RollDice(),
    () => EndTurn() // 余分
});

// ✅OK: ボタン数と一致
ui.playerMenuCanvasUI.SetActions(new Action[] {
    () => StartTurn(),
    () => RollDice()
});
```

#### 4. Manager の namespace（単数形）
```csharp
// ❌NG: Scenes（複数形）
namespace Assets.FEScripts.Scenes.Title

// ✅OK: Scene（単数形）
namespace Assets.FEScripts.Scene.Title
```

---

### BEScript

#### 1. Entity の不変性
```csharp
// ❌NG: publicセッター
public string name { get; set; }

// ✅OK: プライベートフィールド + publicゲッター
private string _name;
public string name { get { return _name; } }
```

#### 2. Repository の初期化
```csharp
// ❌NG: 初期化チェックなし
public async UniTask<PlayerEntity[]> FindAll()
{
    return Array.ConvertAll(_model.list, PlayerEntity.CreateFromModel);
}

// ✅OK: 必ず初期化チェック
public async UniTask<PlayerEntity[]> FindAll()
{
    if (_model == null) await Initialize();
    return Array.ConvertAll(_model.list, PlayerEntity.CreateFromModel);
}
```

#### 3. DI.cs への登録
```csharp
// ❌NG: DI.csに登録せずに直接インスタンス化
var service = new GetPlayersService(new PlayerRepository());

// ✅OK: DI.csで一元管理
public static class DI
{
    public static GetPlayersService getPlayersService = new GetPlayersService(
        new PlayerRepository()
    );
}
// 使用時
var service = DI.getPlayersService;
```

#### 4. 依存関係の方向
```csharp
// ❌NG: Domainが外側のレイヤーに依存
namespace Assets.BEScripts.Domains.Entities
{
    using Assets.BEScripts.Infrastructures.Repositories; // NG!
}

// ✅OK: 外側が内側に依存
namespace Assets.BEScripts.Infrastructures.Repositories
{
    using Assets.BEScripts.Domains.Entities; // OK
}
```

#### 5. エラーハンドリング
```csharp
// ❌NG: nullチェックなし
public async UniTask<PlayerEntity> FindByUid(string uid)
{
    var result = Array.Find(_model.list, _ => _.uid == uid);
    return PlayerEntity.CreateFromModel(result); // nullの場合エラー
}

// ✅OK: 適切なエラーハンドリング
public async UniTask<PlayerEntity> FindByUid(string uid)
{
    if (_model == null) await Initialize();
    
    var result = Array.Find(_model.list, _ => _.uid == uid);
    if (result == null)
        throw new Exception($"Player with UID {uid} not found.");
    
    return PlayerEntity.CreateFromModel(result);
}
```

---

## 📂 新規シーン作成の流れ

詳細は [copilot-instructions-fescript-architecture.md](./copilot-instructions-fescript-architecture.md#新規シーン作成手順) を参照。

**基本ステップ**:
1. フォルダ作成: `Scenes/[シーン名]/CanvasUI/`
2. Entity作成: データ定義
3. UI作成: Canvas参照とCanvasUI管理
4. Manager作成: ライフサイクル実装（InitEntity/InitUI/InitEvent/InitOriginProcess）
5. CanvasUI作成: 各Canvas分の制御クラス

**プロンプト例**:
```
FEScripts/Scenesの中のフォルダを参考に、このフォルダに[シーン名]フォルダを作成してほしいです
それぞれEntity、UI、Managerの作成及び、以下Canvas用のCanvasUIを作成してほしいです
・[Canvas1]Canvas
・[Canvas2]Canvas
```

---

## 🔍 トラブルシューティング

### FEScript

**1. NullReferenceException in CanvasUI**
```
原因: GameObject.Find("Canvas名")が失敗
対策: Unity上のGameObject名とコードが完全一致しているか確認
```

**2. SetActions実行時のIndexOutOfRangeException**
```
原因: Action配列の要素数とボタン数が不一致
対策: CanvasUI内のボタン数を確認してAction配列を調整
```

**3. HeaderCanvasがnull**
```
原因: AbstractUI.InitCanvas()のbase呼び出し忘れ
対策: protected override void InitCanvas()の先頭でbase.InitCanvas()を呼ぶ
```

---

### BEScript

**1. Repository初期化エラー**
```
原因: Initialize()を呼ばずにデータアクセス
対策: 各メソッドの先頭で if (_model == null) await Initialize(); を追加
```

**2. PlayFabModelがnull**
```
原因: PlayFabModel.Initialize***()の呼び忘れ
対策: ゲーム起動時にPlayFabModel.InitializeLogin(), InitializeUserData()等を実行
```

**3. DI経由でのController呼び出しエラー**
```
原因: DI.csに登録されていない
対策: DI.csでServiceとControllerを初期化してからFEScriptsで使用
```

**4. Entity変換時のNullReferenceException**
```
原因: CreateFromModel()にnullを渡している
対策: Array.Find()の結果をnullチェックしてからEntityに変換
```

**5. JSON デシリアライズエラー**
```
原因: PlayFabから取得したデータの形式が不正
対策: try-catchでエラーハンドリング、空データチェックを追加
```

---

## 📖 参考資料

- [FEScript アーキテクチャ詳細ドキュメント](./copilot-instructions-fescript-architecture.md)
- [BEScript アーキテクチャ詳細ドキュメント](./copilot-instructions-bescript-architecture.md)
- [シーン作成プロンプト集](./prompt/create-scene-structure.md)
- 実装参考シーン:
  - `Assets/FEScripts/Scenes/Title/` - 基本構造
  - `Assets/FEScripts/Scenes/Battle/` - 複雑なCanvas制御
  - `Assets/FEScripts/Scenes/Menu/` - キャラクター選択UI

---
## 🎓 学習の進め方

1. **アーキテクチャ理解**: 
   - FEScript: [copilot-instructions-fescript-architecture.md](./copilot-instructions-fescript-architecture.md) を読む
   - BEScript: [copilot-instructions-bescript-architecture.md](./copilot-instructions-bescript-architecture.md) を読む
2. **既存コード参照**: 
   - FEScript: `Scenes/Title/` の実装を確認
   - BEScript: `UseCases/Players/`, `Presentations/Players/` の実装を確認
3. **新規作成実践**: テンプレートを使って練習シーンを作成
4. **コード品質向上**: このドキュメントの規約に従ってリファクタリング


---
