# Copilot Instructions - Unity BEScripts アーキテクチャ

## プロジェクト概要

このプロジェクトの BEScripts は Unity 上で動作するバックエンドロジックを担当します。クリーンアーキテクチャをベースに、**Repository/Service/Controller** パターンで設計されています。PlayFabをバックエンドとして使用し、データの取得・更新・永続化を行います。

---

## ディレクトリ構造

```
Assets/BEScripts/
├── DI.cs                       # 依存性注入の設定
├── Setting.cs                  # グローバル設定
├── Domains/                    # ドメイン層
│   ├── Entities/               # エンティティ（ビジネスロジック）
│   ├── Interfaces/             # リポジトリインターフェース
│   │   ├── Repositories/
│   │   ├── Services/
│   │   └── Types/
│   ├── Types/                  # ドメイン型定義
│   └── Abstracts/              # 抽象クラス
├── UseCases/                   # ユースケース層
│   ├── Players/
│   │   ├── Services/           # ビジネスロジック実装
│   │   └── Dto/                # データ転送オブジェクト
│   ├── Enemies/
│   ├── Consumables/
│   ├── NoConsumables/
│   └── Subscriptions/
├── Infrastructures/            # インフラ層
│   ├── Repositories/           # データアクセス実装
│   ├── Models/                 # 外部API/DB接続
│   │   └── PlayFab/            # PlayFab API実装
│   ├── Configs/                # 設定
│   └── Middlewares/            # ミドルウェア
│       ├── Data/
│       ├── Login/
│       ├── TitleData/
│       ├── UserData/
│       └── CatalogList/
├── Presentations/              # プレゼンテーション層
│   ├── Players/
│   │   ├── Controllers/        # コントローラー
│   │   └── Responses/          # レスポンス変換
│   ├── Enemies/
│   ├── Consumables/
│   ├── NoConsumables/
│   └── Subscriptions/
└── BETests/                    # テスト
    ├── Units/                  # ユニットテスト
    │   ├── Entities/
    │   └── Repositories/
    ├── Integrations/           # 統合テスト
    └── Data/                   # テストデータ
```

---

## アーキテクチャパターン

### レイヤー構成（クリーンアーキテクチャ）

```
[Presentation Layer]
    ↓ 依存
[UseCase Layer]
    ↓ 依存
[Domain Layer]
    ↑ 実装
[Infrastructure Layer]
```

依存関係は内側（Domain）に向かう一方向のみ。外側のレイヤーは内側に依存しますが、逆は禁止されています。

---

## 各層の責務

### 1. Domain層（ドメイン層）

#### **Entities（エンティティ）**
- **役割**: ビジネスロジックとデータ構造の定義
- **特徴**: 
  - 不変オブジェクト（プライベートフィールド、publicゲッター）
  - ビジネスルールを持つ
  - 他の層に依存しない

```csharp
namespace Assets.BEScripts.Domains.Entities
{
    public class PlayerEntity
    {
        private string _uid;
        private string _name;
        private int _maxHp;
        private int _maxMp;
        private int _attack;
        private int _defense;
        private int _speed;

        public PlayerEntity(
            string uid,
            string name,
            string nameId,
            int maxHp,
            int maxMp,
            int attack,
            int defense,
            int speed
        )
        {
            _uid = uid;
            _name = name;
            // ...
        }

        // Modelからの変換用ファクトリメソッド
        public static PlayerEntity CreateFromModel(PlayerListType _param)
        {
            return new PlayerEntity(
                _param.uid,
                _param.name,
                _param.nameId,
                _param.maxHp,
                _param.maxMp,
                _param.attack,
                _param.defense,
                _param.speed
            );
        }

        public string uid { get { return _uid; } }
        public string name { get { return _name; } }
        // ... その他のプロパティ
    }
}
```

#### **Interfaces（インターフェース）**
- **役割**: Repository/Serviceの契約定義
- **場所**: `Domains/Interfaces/Repositories/`, `Domains/Interfaces/Services/`

#### **Types（型定義）**
- **役割**: ドメイン内で使用する型・構造体定義
- **例**: `ModelParams`, `Responses`

---

### 2. UseCase層（ユースケース層）

#### **Services（サービス）**
- **役割**: アプリケーションのビジネスロジック実装
- **責務**:
  - Repository から Entity を取得
  - ビジネスロジックを適用
  - Dto に変換して返却
- **命名**: `[操作名]Service.cs` (例: GetPlayersService, SavePlayerService)

```csharp
namespace Assets.BEScripts.UseCases.Players.Services
{
    public class GetPlayersService
    {
        private PlayerRepository _playerRepository;

        // コンストラクタでリポジトリを注入
        public GetPlayersService(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        // ビジネスロジックの実行
        public async UniTask<GetPlayersResponseDto> Execute()
        {
            // Repository から全プレイヤーを取得
            PlayerEntity[] result = await _playerRepository.FindAll();
            
            // Dto に変換して返却
            return new GetPlayersResponseDto(result);
        }
    }
}
```

#### **Dto（データ転送オブジェクト）**
- **役割**: レイヤー間のデータ受け渡し
- **特徴**:
  - Service → Controller への橋渡し
  - Entity の配列をラップ
- **命名**: `[操作名]ResponseDto.cs`

```csharp
namespace Assets.BEScripts.UseCases.Players.Dto
{
    public class GetPlayersResponseDto
    {
        public PlayerEntity[] players;

        public GetPlayersResponseDto(PlayerEntity[] players)
        {
            this.players = players;
        }
    }
}
```

---

### 3. Infrastructure層（インフラ層）

#### **Repositories（リポジトリ）**
- **役割**: データの永続化・取得の具体的実装
- **責務**:
  - PlayFabModel を使用したデータアクセス
  - Model ↔ Entity 変換
  - CRUD操作の実装
- **命名**: `[エンティティ名]Repository.cs`

```csharp
namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class PlayerRepository
    {
        private PlayerModelType _model;

        // データの初期化
        public async UniTask Initialize()
        {
            string data = await PlayFabModel.userData.GetUserData(Setting.PLAYER_DATA_KEY);
            if (string.IsNullOrEmpty(data))
            {
                // 新規作成
                _model = new PlayerModelType { list = new PlayerListType[0] };
            }
            else
            {
                // デシリアライズ
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
            return modelParam != null ? PlayerEntity.CreateFromModel(modelParam) : null;
        }

        // 保存
        public async UniTask Save(PlayerEntity player)
        {
            if (_model == null) await Initialize();
            
            int index = Array.FindIndex(_model.list, _ => _.uid == player.uid);
            if (index < 0)
                throw new Exception($"Player with UID {player.uid} not found.");

            // モデルを更新
            _model.list[index] = new PlayerListType
            {
                uid = player.uid,
                name = player.name,
                // ...
            };

            // PlayFabに保存
            string json = JsonConvert.SerializeObject(_model);
            await PlayFabModel.userData.UpdateUserData(Setting.PLAYER_DATA_KEY, json);
        }
    }
}
```

#### **Models（モデル）**
- **役割**: 外部APIとの通信実装
- **PlayFabModel**: PlayFab API のラッパー
  - `login` - ログイン処理
  - `titleData` - タイトルデータ取得
  - `userData` - ユーザーデータ取得/更新
  - `catalogList` - カタログデータ取得

```csharp
namespace Assets.BEScripts.Infrastructures.Models.PlayFab
{
    public static class PlayFabModel
    {
        private static Login _login;
        public static Login login { get { return _login; } }
        
        private static UserData _userData;
        public static UserData userData { get { return _userData; } }
        
        public static void InitializeLogin()
        {
            _login = new Login();
        }
        
        public static void InitializeUserData()
        {
            _userData = new UserData();
        }
    }
}
```

#### **Middlewares（ミドルウェア）**
- **役割**: 横断的な処理（認証、データ取得制御等）
- **種類**:
  - `LoginController` - ログイン処理
  - `BringUserDataController` - ユーザーデータ取得
  - `BringTitleDataController` - タイトルデータ取得

---

### 4. Presentation層（プレゼンテーション層）

#### **Controllers（コントローラー）**
- **役割**: FEScripts からの API エンドポイント
- **責務**:
  - Service の実行
  - Response への変換
  - エラーハンドリング
- **命名**: `[操作名]Controller.cs`

```csharp
namespace Assets.BEScripts.Presentations.Players.Controllers
{
    public class GetPlayersController : MonoBehaviour
    {
        private readonly GetPlayersService _getPlayersService;
        
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
}
```

#### **Responses（レスポンス）**
- **役割**: Dto → ResponseType への変換
- **特徴**:
  - FEScripts 向けの型に変換
  - 必要に応じてデータ整形

```csharp
namespace Assets.BEScripts.Presentations.Players.Responses
{
    public class GetPlayersResponse
    {
        public GetPlayersResponseType ToResponse(GetPlayersResponseDto dto)
        {
            PlayerDataType[] _players = new PlayerDataType[dto.players.Length];
            for (int i = 0; i < dto.players.Length; i++)
            {
                _players[i] = new PlayerDataType
                {
                    uid = dto.players[i].uid,
                    name = dto.players[i].name,
                    maxHp = dto.players[i].maxHp,
                    // ...
                };
            }
            return new GetPlayersResponseType { list = _players };
        }
    }
}
```

---

## 依存性注入（DI）

`DI.cs` で全ての依存関係を管理します。

```csharp
namespace Assets.BEScripts
{
    public static class DI
    {
        // Service の初期化（Repository を注入）
        public static GetPlayersService getPlayersService = new GetPlayersService(
            new PlayerRepository()
        );

        // Controller の初期化（Service を注入）
        public static GetPlayersController getPlayersController = new GetPlayersController(
            getPlayersService
        );
    }
}
```

**FEScripts からの呼び出し例**:
```csharp
// FEScripts の Manager から
GetPlayersResponseType response = await DI.getPlayersController.Execute();
```

---

## 命名規則

### ファイル名
- Entity: `[名前]Entity.cs` (例: PlayerEntity.cs)
- Repository: `[名前]Repository.cs` (例: PlayerRepository.cs)
- Service: `[操作名]Service.cs` (例: GetPlayersService.cs)
- Controller: `[操作名]Controller.cs` (例: GetPlayersController.cs)
- Dto: `[操作名]ResponseDto.cs` (例: GetPlayersResponseDto.cs)
- Response: `[操作名]Response.cs` (例: GetPlayersResponse.cs)

### namespace
- Domain: `Assets.BEScripts.Domains.[カテゴリ]`
- UseCase: `Assets.BEScripts.UseCases.[ドメイン名].[Service/Dto]`
- Infrastructure: `Assets.BEScripts.Infrastructures.[カテゴリ]`
- Presentation: `Assets.BEScripts.Presentations.[ドメイン名].[Controllers/Responses]`

### クラス名・メソッド名
- PascalCase
- 操作名は動詞で始める（Get, Save, Update, Delete）

---

## 新規機能作成手順

### 例: 新しいエンティティ「Item」の取得機能を作成

#### 1. Entity作成
**場所**: `Domains/Entities/ItemEntity.cs`

```csharp
namespace Assets.BEScripts.Domains.Entities
{
    public class ItemEntity
    {
        private string _uid;
        private string _name;
        private int _price;

        public ItemEntity(string uid, string name, int price)
        {
            _uid = uid;
            _name = name;
            _price = price;
        }

        public static ItemEntity CreateFromModel(ItemListType _param)
        {
            return new ItemEntity(_param.uid, _param.name, _param.price);
        }

        public string uid { get { return _uid; } }
        public string name { get { return _name; } }
        public int price { get { return _price; } }
    }
}
```

#### 2. Repository作成
**場所**: `Infrastructures/Repositories/ItemRepository.cs`

```csharp
namespace Assets.BEScripts.Infrastructures.Repositories
{
    public class ItemRepository
    {
        private ItemModelType _model;

        public async UniTask Initialize()
        {
            string data = await PlayFabModel.userData.GetUserData(Setting.ITEM_DATA_KEY);
            _model = JsonConvert.DeserializeObject<ItemModelType>(data);
        }

        public async UniTask<ItemEntity[]> FindAll()
        {
            if (_model == null) await Initialize();
            return Array.ConvertAll(_model.list, ItemEntity.CreateFromModel);
        }
    }
}
```

#### 3. Dto作成
**場所**: `UseCases/Items/Dto/GetItemsResponseDto.cs`

```csharp
namespace Assets.BEScripts.UseCases.Items.Dto
{
    public class GetItemsResponseDto
    {
        public ItemEntity[] items;

        public GetItemsResponseDto(ItemEntity[] items)
        {
            this.items = items;
        }
    }
}
```

#### 4. Service作成
**場所**: `UseCases/Items/Services/GetItemsService.cs`

```csharp
namespace Assets.BEScripts.UseCases.Items.Services
{
    public class GetItemsService
    {
        private ItemRepository _itemRepository;

        public GetItemsService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async UniTask<GetItemsResponseDto> Execute()
        {
            ItemEntity[] result = await _itemRepository.FindAll();
            return new GetItemsResponseDto(result);
        }
    }
}
```

#### 5. Response作成
**場所**: `Presentations/Items/Responses/GetItemsResponse.cs`

```csharp
namespace Assets.BEScripts.Presentations.Items.Responses
{
    public class GetItemsResponse
    {
        public GetItemsResponseType ToResponse(GetItemsResponseDto dto)
        {
            ItemDataType[] _items = new ItemDataType[dto.items.Length];
            for (int i = 0; i < dto.items.Length; i++)
            {
                _items[i] = new ItemDataType
                {
                    uid = dto.items[i].uid,
                    name = dto.items[i].name,
                    price = dto.items[i].price
                };
            }
            return new GetItemsResponseType { list = _items };
        }
    }
}
```

#### 6. Controller作成
**場所**: `Presentations/Items/Controllers/GetItemsController.cs`

```csharp
namespace Assets.BEScripts.Presentations.Items.Controllers
{
    public class GetItemsController : MonoBehaviour
    {
        private readonly GetItemsService _getItemsService;

        public GetItemsController(GetItemsService getItemsService)
        {
            _getItemsService = getItemsService;
        }

        public async UniTask<GetItemsResponseType> Execute()
        {
            GetItemsResponse response = new GetItemsResponse();
            GetItemsResponseDto dto = await _getItemsService.Execute();
            return response.ToResponse(dto);
        }
    }
}
```

#### 7. DI登録
**場所**: `DI.cs`

```csharp
public static class DI
{
    // Service
    public static GetItemsService getItemsService = new GetItemsService(
        new ItemRepository()
    );

    // Controller
    public static GetItemsController getItemsController = new GetItemsController(
        getItemsService
    );
}
```

---

## テストパターン

### Unit Test（ユニットテスト）
**場所**: `BETests/Units/`

#### Entity のテスト
```csharp
namespace Assets.BEScripts.BETests.Units.Entities
{
    [TestFixture]
    public class PlayerEntityTest
    {
        [Test]
        public void CreateFromModel_正常系_Entityが生成される()
        {
            // Arrange
            var model = new PlayerListType
            {
                uid = "player1",
                name = "Test Player",
                maxHp = 100
            };

            // Act
            var entity = PlayerEntity.CreateFromModel(model);

            // Assert
            Assert.AreEqual("player1", entity.uid);
            Assert.AreEqual("Test Player", entity.name);
            Assert.AreEqual(100, entity.maxHp);
        }
    }
}
```

#### Repository のテスト
```csharp
namespace Assets.BEScripts.BETests.Units.Repositories
{
    [TestFixture]
    public class PlayerRepositoryTest
    {
        [Test]
        public async UniTask FindAll_データ存在_全プレイヤー取得()
        {
            // Arrange
            var repository = new PlayerRepository();

            // Act
            var result = await repository.FindAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.Greater(result.Length, 0);
        }
    }
}
```

### Integration Test（統合テスト）
**場所**: `BETests/Integrations/`

API全体のフローをテスト:
```csharp
[Test]
public async UniTask GetPlayers_正常系_全プレイヤー取得成功()
{
    // Arrange
    var controller = DI.getPlayersController;

    // Act
    var response = await controller.Execute();

    // Assert
    Assert.IsNotNull(response);
    Assert.Greater(response.list.Length, 0);
}
```

---

## ベストプラクティス

### 1. 依存関係の方向
- 外側（Presentation/Infrastructure）→ 内側（Domain）
- 逆方向の依存は禁止

### 2. Entityの不変性
```csharp
// ✅ OK: プライベートフィールド、publicゲッター
private string _name;
public string name { get { return _name; } }

// ❌ NG: publicセッター
public string name { get; set; }
```

### 3. Repositoryの責務
- データアクセスのみ
- ビジネスロジックは Service に記述

### 4. 非同期処理
- 全ての Repository メソッドは `async UniTask`
- PlayFab API は非同期呼び出し

### 5. エラーハンドリング
```csharp
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

## 参照実装例

### Players（プレイヤー管理）
- **Entity**: `PlayerEntity.cs`
- **Repository**: `PlayerRepository.cs` - FindAll, FindByUid, Save
- **Service**: `GetPlayersService.cs`
- **Controller**: `GetPlayersController.cs`

### Enemies（敵キャラ管理）
- **Entity**: `EnemyEntity.cs`
- **Repository**: `EnemyRepository.cs`
- **Service**: `GetEnemiesService.cs`
- **Controller**: `GetEnemiesController.cs`

### Consumables（消耗品管理）
- **Entity**: `ConsumableEntity.cs`
- **Repository**: `ConsumableRepository.cs`
- **Service**: `GetConsumablesService.cs`
- **Controller**: `GetConsumablesController.cs`

---

## TODO テンプレート

新規機能作成時は TODO コメントを含める:

```csharp
public async UniTask<ItemEntity[]> FindAll()
{
    // TODO: データ取得処理を実装
    throw new NotImplementedException();
}
```

---

## 注意事項

1. **Repository は必ず Initialize() を呼ぶ**
   - データアクセス前に `_model` の初期化が必要

2. **Entity ↔ Model 変換は Entity で定義**
   - `CreateFromModel()` 静的メソッドを使用

3. **DI.cs に必ず登録**
   - Service と Controller は DI.cs で初期化

4. **namespace の単数形/複数形**
   - `UseCases.Players` (複数形)
   - `Domains.Entities` (複数形)

5. **PlayFabModel の初期化**
   - 各 Model は使用前に `PlayFabModel.Initialize***()` を呼び出す

---

## クイックリファレンス

### 新規機能作成チェックリスト
- [ ] Entity作成（`Domains/Entities/`）
- [ ] Repository作成（`Infrastructures/Repositories/`）
- [ ] Dto作成（`UseCases/[Domain]/Dto/`）
- [ ] Service作成（`UseCases/[Domain]/Services/`）
- [ ] Response作成（`Presentations/[Domain]/Responses/`）
- [ ] Controller作成（`Presentations/[Domain]/Controllers/`）
- [ ] DI.cs に登録
- [ ] Unit Test作成（`BETests/Units/`）

### データフロー
```
FEScripts
    ↓
Controller.Execute()
    ↓
Service.Execute()
    ↓
Repository.FindAll()
    ↓
PlayFabModel
    ↓
Entity ← CreateFromModel()
    ↓
Dto
    ↓
Response.ToResponse()
    ↓
ResponseType → FEScripts
```
