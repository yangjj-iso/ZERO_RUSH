# 更新日志和计划

***Vesta：部分AI写的挺不错，初稿待修待审***

## 团队成员与分工

* **PICO**: 主程序
  * 负责：分支管理，技术架构设计，技术决策和攻坚，代码质量监控，提供技术支持。
* **Vesta**:
  * 负责：项目审阅，与策划对接，提出意见和计划，部分敲代码，编写日志，汇报进度等打杂工作。
* **HCS**:
  * 负责：实现玩家和敌人的所有战斗逻辑、技能、武器系统，让敌人“聪明“地动起来，负责玩家与场景中交互。
* **sine**:
  * 负责：负责所有游戏内外的界面，如主菜单、HUD等，实现所有按钮、滑动、拖拽等用户交互，与美术协同，负责游戏存档/读档，场景跳转，音乐播放等与游戏玩法无关的系统功能。
* **待定**：
  *负责：负责将美术的动画资源在游戏中播放出来，并制作刀光、受击等基本特效以及粒子特效等，负责角色、怪物、场景物件的动画状态机和动画逻辑，编写特殊效果的Shader，优化渲染管线。  

*注意：各成员需在下方计划中明确自己负责的具体内容。*

---

## 开发流程

### Git 工作流

我们采用 **GitFlow** 的简化版本作为我们的协作流程。

* `main`: 主分支，存放随时可以部署的、最稳定的正式版本。只接受来自 `develop` 分支的合并。
* `develop`: 开发分支，存放最新开发完成的功能。所有功能分支都从这里创建，并合并回这里。
* `feature/<feature-name>`: 功能分支，用于开发新功能。开发完成后合并到 `develop` 分支。
* `bugfix/<bug-name>`: Bug修复分支，用于修复 `develop` 分支上的 Bug。修复后合并回 `develop`。
* `hotfix/<fix-name>`: 紧急修复分支，用于修复 `main` 分支上的紧急 Bug。修复后同时合并到 `main` 和 `develop`。

### Commit 消息规范

请遵循 **Conventional Commits** 规范来编写 Commit 消息，格式如下：

```
<type>(<scope>): <subject>
<BLANK LINE>
<body>
<BLANK LINE>
<footer>
```

* **type**: `feat` (新功能), `fix` (修复Bug), `docs` (文档), `style` (格式), `refactor` (重构), `test` (测试), `chore` (构建或辅助工具)
* **scope**: 可选，表示影响范围 (例如: `player`, `ui`, `server`)
* **subject**: 简短描述

**示例:**
`feat(player): add jump functionality`
`fix(ui): correct spelling in main menu`

### Pull Request (PR) 流程

1. 当一个功能开发完成或一个 Bug 修复后，从你的功能分支向 `develop` 分支发起一个 Pull Request。
2. 在 PR 描述中清晰地说明你做了什么。
3. 至少需要 **一名** 其他成员进行代码审查 (Code Review)。
4. 审查通过后，由 PR 发起者将代码合并到 `develop` 分支，并删除源功能分支。

---

## 版本号说明

版本号格式为 `V a.b.c.d`：

* **a (Major)**: 游戏大版本。当发生重大变更或重做时增加。
* **b (Minor/Release)**: 正式版。当发布一个包含了新功能、内容完整、且相对稳定的版本时增加。此版本可交付给测试人员或玩家。
* **c (Patch/Beta)**: 测试版/补丁版。主要用于 Bug 修复。当一个版本发布后，为其修复 Bug 时增加。
* **d (Build)**: 快照/编译版。每次自动化构建或内部存档时递增，用于记录开发过程中的小进度。

**示例**: `v1.0.0.1` -> `v1.0.1.0` (修复了bug) -> `v1.1.0.0` (增加了新功能)

---

## 代码规范 (C# for Unity)

### 1. 命名规范

* **类、接口、结构体、枚举、方法、属性、事件**: `PascalCase`
  * `public class PlayerController`
  * `public interface IDamageable`
* **参数、局部变量**: `camelCase`
  * `int localPlayerId`
* **私有字段**: `_camelCase` (以下划线开头)
  * `private int _playerHealth;`
* **常量 (const, readonly static)**: `ALL_CAPS`
  * `public const int MAX_PLAYERS = 4;`
* **布尔变量/属性**: 应该听起来像一个问题，例如 `isDead`, `canJump`, `hasWeapon`。

### 2. 注释和文档

* ***所有公开的 (public) 类、方法、属性都必须有 XML 文档注释 (`///`)！！！***
* 注释的目的是解释 **"为什么"** 这么做，而不是 **"是什么"**。代码本身应该能清晰地说明它是什么。
* 对于复杂的算法或逻辑，应添加注释解释其工作原理。
* 过时的代码不要注释掉，直接删除。Git 会保存历史记录。

### 3. 格式化

* **大括号**: 使用 Allman 风格，将大括号放在新的一行。

  ```csharp
  public void MyFunction(){
      // ...
  }
  ```
* **空行**: 使用空行来分隔逻辑上不同的代码块，以提高可读性。

### 4. 最佳实践

* **单一职责原则 (SRP)**: 每个类和方法应该只做一件事情。
* **避免魔法数**: 使用 `const` 或 `enum` 代替硬编码的数字或字符串。
* **善用 `readonly`**: 如果一个字段只在构造函数中被赋值，请标记为 `readonly`。
* **访问修饰符**: 总是显式指定访问修饰符 (`public`, `private`, `protected`)。默认为 `private`。
* **属性 vs. 公共字段**: 优先使用属性 (`{ get; set; }`) 而不是公共字段，以便于未来扩展。
* **空引用检查**: 在使用对象之前，检查它是否为 `null`。
* **命名空间**: 使用命名空间来组织代码，避免命名冲突。例如 `YourGame.Player`, `YourGame.UI`。

---

## 更新日志 (Changelog)

每次发布新版本 (`main` 分支更新) 时，都需要在此处记录更新内容。

### [Unreleased]

* ...

### V1.0.0.0 - 2024-MM-DD

* **Added**
  * ...
* **Changed**
  * ...
* **Fixed**
  * ...
* **Removed**
  * ...
