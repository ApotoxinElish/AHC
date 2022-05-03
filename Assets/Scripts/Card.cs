using System.Collections.Generic;

// /// <summary>
// /// 卡牌类型
// /// </summary>
// public enum Cardtype
// {
//     investigatorCard,
//     assetCard, eventCard, skillCard,
//     scenarioCard, agendaCard, actCard, locationCard,
//     enemyCard, treacheryCard
// }

public enum SubType
{
    nonWeakness, basicWeakness, weakness
}

/// <summary>
/// 职阶符号
/// </summary>
public enum ClassSymbol
{
    neutral, guardian, seeker, mystic, rogue, survivor
}

/// <summary>
/// 技能检定图标
/// </summary>
public enum SkillTestIcons
{
    wild, willpower, intellect, combat, agility
}

public enum Slot
{
    nonSlot, ally, body, accessory, hand, arcane
}

/// <summary>
/// 卡牌
/// </summary>
public class Card
{
    public int id;
    // /// <summary>
    // /// 卡牌类型
    // /// Indicates how a card behaves or may be used in the game.
    // /// </summary>
    // public Cardtype cardtype;
    public SubType subType;
    /// <summary>
    /// 名称
    /// The name of this card.
    /// </summary>
    public string title;
    /// <summary>
    /// 副名称
    /// A secondary identifier for a card.
    /// </summary>
    public string subtitle;
    /// <summary>
    /// 属性
    /// Flavorful attributes that may be referenced by card abilities.
    /// </summary>
    public List<string> traits;
    /// <summary>
    /// 能力
    /// This card's specialized means of interacting with the game.
    /// </summary>
    public string ability;
    /// <summary>
    /// 产品图标
    /// Indicates this card's product of origin.
    /// </summary>
    public int productSetInformation;

    public Card(int _id, string _title)
    {
        this.id = _id;
        this.title = _title;
    }
}

/// <summary>
/// 玩家卡
/// </summary>
public class PlayerCard : Card
{
    /// <summary>
    /// 等级
    /// The amount of experience required to purchase this card for a deck.
    /// </summary>
    public int level;
    /// <summary>
    /// 职阶符号
    /// The class to which a card belongs. Neutral cards have no class symbol.
    /// </summary>
    public ClassSymbol classSymbol;
    /// <summary>
    /// 技能检定图标
    /// Modify skill value while committed to a skill test.
    /// </summary>
    public Dictionary<SkillTestIcons, int> skillTestIcons;

    public PlayerCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 调查员卡
/// </summary>
public class InvestigatorCard : PlayerCard
{
    /// <summary>
    /// 技能
    /// This investigator's value for his or her skills, in order: Willpower, Intellect, Combat, Agility.
    /// </summary>
    public Dictionary<SkillTestIcons, int> skills;
    /// <summary>
    /// 远古印记能力
    /// This investigator's ability for the Elder Sign token.
    /// </summary>
    public string elderSignAbility;
    /// <summary>
    /// 生命值
    /// This card's health value, which measures its physical durability.
    /// </summary>
    public int health;
    public int healthMax;
    /// <summary>
    /// 神智值
    /// This card's sanity value, which measures its mental durability.
    /// </summary>
    public int sanity;
    public int sanityMax;

    public InvestigatorCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 支援卡
/// </summary>
public class AssetCard : PlayerCard
{
    /// <summary>
    /// 费用
    /// The resource cost to play a card.
    /// </summary>
    public int cost;
    /// <summary>
    /// 生命值
    /// This card's health value, which measures its physical durability.
    /// </summary>
    public int health;
    public int healthMax;
    /// <summary>
    /// 神智值
    /// This card's sanity value, which measures its mental durability.
    /// </summary>
    public int sanity;
    public int sanityMax;

    public Dictionary<Slot, int> slot;

    public AssetCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 事件卡
/// </summary>
public class EventCard : PlayerCard
{
    /// <summary>
    /// 费用
    /// The resource cost to play a card.
    /// </summary>
    public int cost;

    public EventCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 技能卡
/// </summary>
public class SkillCard : PlayerCard
{
    public SkillCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 冒险卡
/// </summary>
public class ScenarioCard : Card
{
    /// <summary>
    /// 遭遇组符号
    /// Indicates which encounter set the card belongs to.
    /// </summary>
    public string encounterSetSymbol;
    /// <summary>
    /// 遭遇组牌数
    /// Indicates the number of cards within an encounter set, and this card's place within that set.
    /// </summary>
    public int encounterSetNumber;

    public ScenarioCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 冒险辅助卡
/// </summary>
public class ScenarioReferenceCard : ScenarioCard
{
    public ScenarioReferenceCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 密谋卡
/// </summary>
public class AgendaCard : ScenarioCard
{
    /// <summary>
    /// 密谋编号
    /// Used to order the agenda deck.
    /// </summary>
    public int agendaSequence;
    /// <summary>
    /// 毁灭目标值
    /// The amount of doom in play required to advance this agenda.
    /// </summary>
    public int doomThreshold;

    public AgendaCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 场景卡
/// </summary>
public class ActCard : ScenarioCard
{
    /// <summary>
    /// 场景编号
    /// Used to order the act deck.
    /// </summary>
    public int actSequence;
    /// <summary>
    /// 线索目标值
    /// The number of clues that must be spent to advance this act.
    /// </summary>
    public int clueThreshold;

    public ActCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 地点卡
/// </summary>
public class LocationCard : ScenarioCard
{
    /// <summary>
    /// 隐藏值
    /// Determines the difficulty of a skill test to investigate this location.
    /// </summary>
    public int shroud;
    /// <summary>
    /// 线索值
    /// The number of clues placed on this location when it is first revealed.
    /// </summary>
    public int clueValue;
    /// <summary>
    /// 连接符号
    /// Indicate the movement connections between locations.
    /// </summary>
    public List<string> connectionSymbols;

    public bool unrevealed;

    public LocationCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 敌人卡
/// </summary>
public class EnemyCard : ScenarioCard
{
    /// <summary>
    /// 敌人攻击值
    /// Determines the difficulty of a skill test to attack this enemy.
    /// </summary>
    public int enemyFightValue;
    /// <summary>
    /// 敌人生命值
    /// This enemy's health value, which measures its physical durability.
    /// </summary>
    public int enemyHealthValue;
    public int enemyHealthValueMax;
    /// <summary>
    /// 敌人躲避值
    /// Determines the difficulty of a skill test to evade this enemy.
    /// </summary>
    public int enemyEvadeValue;
    /// <summary>
    /// 伤害
    /// The amount of damage this enemy deals with its attack.
    /// </summary>
    public int damage;
    /// <summary>
    /// 恐惧
    /// The amount of horror this enemy deals with its attack.
    /// </summary>
    public int horror;

    public EnemyCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 诡计卡
/// </summary>
public class TreacheryCard : ScenarioCard
{
    public TreacheryCard(int _id, string _title) : base(_id, _title)
    {

    }
}
