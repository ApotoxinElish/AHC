# AHC

## 阶段流程表

1.  神话阶段（游戏第一轮跳过该阶段）

    - 一轮开始。神话阶段开始。
    - 在当前密谋卡上放置 1 个毁灭标记。
    - 检查毁灭数量。
    - 每位调查员抽取 1 张遭遇卡。
      - 玩家时间段
    - 神话阶段结束。
      - 进入调查阶段。

2.  调查阶段

    - 调查阶段开始。
      - 玩家时间段
    - 下一位调查员回合开始。
      - 玩家时间段
      - 当前调查员如果还有行动剩余，可以执行 1 个行动。如果执行行动则返回先前的玩家时间段；如果行动用完，则进入 调查员回合结束
      - 调查员回合结束。如果该阶段中，还有未执行回合的调查员则返回 下一位调查员回合开始。如果所有调查员都已完成回合，则进入 调查阶段结束。
    - 调查阶段结束。
      - 进入敌军阶段。

3.  敌军阶段

    - 敌军阶段开始。
    - 猎手敌人移动。
      - 玩家时间段
    - 下一位调查员结算交战敌人的攻击。如果还有调查员未结算敌人攻击，则返回先前的玩家时间段；如果所有调查员都完成攻击结算，则进入下一位玩家时间段。
      - 玩家时间段
    - 敌军阶段结束。
      - 进入补给阶段。

4.  补给阶段
    - 补给阶段开始。
      - 玩家时间段
    - 重置行动数。
    - 将所有消耗（横置）卡牌转为准备（重整）状态。
    - 每位调查员抽取 1 张卡牌，并获得 1 个资源。
    - 每位调查员检查手牌上限。
    - 补给阶段结束。一轮结束。
      - 进入下一轮的神话阶段

---

## Required cards

| ID    | Name              | 中文名             |
| ----- | ----------------- | ------------------ |
| 01001 | Roland Banks      | 罗兰·班克斯        |
| 01016 | .45 Automatic     | .45 自动手枪       |
| 01022 | Evidence!         | 证据！             |
| 01087 | Flashlight        | 手电筒             |
| 01088 | Emergency Cache   | 应急物品           |
| 01091 | Overpower         | 压制               |
| 01104 | The Gathering     | 聚集于此           |
| 01105 | What's Going On?! | 到底发生了什么？！ |
| 01108 | Trapped           | 被困于此           |
| 01111 | Study             | 书房               |
| 01159 | Swarm of Rats     | 鼠群               |
| 01164 | Frozen in Fear    | 呆若木鸡           |
| 01165 | Dissonant Voices  | 刺耳之声           |
| 01166 | Ancient Evils     | 远古恶魔           |
| 01167 | Crypt Chill       | 地窖寒风           |
| 01168 | Obscuring Fog     | 朦胧之雾           |

---

## Glossary

## Scripts

### Architecture

- ### Events

  > #### GameEvent
  >
  > 脚本化对象
  > 单一事件，可触发所有记录的监听

  > #### GameEventInt
  >
  > 脚本化对象  
  > 单一整型事件，可触发所有记录的整型监听，并传入数值

- ### Listeners

  > #### GameEventIntListener
  >
  > 整型事件监听  
  > 挂载到需要触发事件的对象上  
  > 监听整型事件

  > #### GameEventListener
  >
  > 事件监听  
  > 挂载到需要触发事件的对象上
  > 监听事件

- ### Variables

  > #### IntVariable
  >
  > 整型变量  
  > 脚本化对象  
  > 作为可以触发整型事件的变量

### Configuration

> #### PlayableCharacterConfiguration
>
> 脚本化对象
> 玩家组件的集合

### Effects

> #### Effect
>
> 脚本化对象
> 卡牌的单一效果

### Runtime

> #### CardObject
>
> 卡牌对象  
> 挂载到卡牌对象上，对改卡牌进行操作
> 能有互动，但不能点击

> #### GameBootstrap
>
> 初始化所有系统并开始游戏

> #### RuntimeCard
>
> 运行时卡牌  
> 不可挂载  
> 记录卡牌模板，其他功能需添加

### Systems

> #### CardSelectionSystem
>
> 卡牌选择系统  
> 主要是卡牌被点击的操作，包括  
> 点击并出牌，拖拽卡牌

> #### DeckDrawingSystem
>
> 牌堆摸牌系统  
> 主要是卡牌在牌堆之间的操作，包括  
> 读取牌库，返回牌数
> 针对 RuntimeCard

> #### HandPresentationSystem
>
> 手牌显示系统
> 对手牌的显示操作
> 针对 CardObject

> #### PhaseManagementSystem
>
> 阶段管理系统
> 对游戏流程中的阶段进行管理

### Templates

> #### CardLibrary
>
> 卡牌库
> 脚本化对象
> 某一牌堆所有卡牌和张数的列表

> #### CardLibraryEntry
>
> 卡牌库条目
> 不可挂载
> 单种卡片的张数

> #### CardTemplate
>
> 卡牌模板
> 脚本化对象
> 储存单张卡牌的信息

> #### CardType
>
> 卡牌类型
> 脚本化对象
> TODO

> #### PlayerTemplate
>
> 脚本化对象
> 玩家属性等，包含牌组

### UI

> #### DeckWidget
>
> 牌堆部件
> 挂载到弃牌堆的组件，用于显示牌数等

> #### DiscardPileWidget
>
> 弃牌堆部件
> 挂载到弃牌堆的组件，用于显示牌数等

> #### EndTurnButton
>
> 结束回合按钮
> 挂载到结束回合按钮上

> #### ResourceWidget
>
> 资源部件
> 挂载到资源组件，作为费用限制出牌

### Utils

> #### CardUtils
>
> 卡牌工具
> 静态类，出牌时检查费用

> #### ListShuffle
>
> 列表洗牌
> 静态类，为 List 增加 Shuffle 洗牌功能

> #### ObjectPool
>
> 对象池
> 挂载到 CardPool，作为所有卡牌对象的父类
