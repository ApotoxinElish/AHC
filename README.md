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

  > #### GameEventInt

- ### Listeners

  > #### GameEventIntListener

  > #### GameEventListener

- ### Variables

  > #### IntVariable

### Runtime

> #### CardObject

> #### RuntimeCard

### Systems

> #### DeckDrawingSystem

> #### HandPresentationSystem

> #### TurnManagementSystem

### Templates

### UI

> #### DeckWidget

> #### DiscardPileWidget

### Utils

> #### ListShuffle

> #### ObjectPool
