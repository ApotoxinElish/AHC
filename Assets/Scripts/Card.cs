public enum Cardtype
{
    assetCard, enemyCard, eventCard, locationCard, skillCard, treacheryCard
}

public enum ClassSymbol
{
    guardian, seeker, mystic, rogue, survivor, neutral
}

/// <summary>
/// 卡牌
/// </summary>
public class Card
{
    public int id;
    /// <summary>
    /// Indicates how a card behaves or may be used in the game.
    /// </summary>
    public string cardtype;
    /// <summary>
    /// The name of this card.
    /// </summary>
    public string title;
    /// <summary>
    /// Flavorful attributes that may be referenced by card abilities.
    /// </summary>
    public string traits;
    /// <summary>
    /// This card's specialized means of interacting with the game.
    /// </summary>
    public string ability;
    /// <summary>
    /// Indicates this card's product of origin.
    /// </summary>
    public string productSetInformation;

    public Card(int _id, string _title)
    {
        this.id = _id;
        this.title = _title;
    }
}

/// <summary>
/// 冒险卡
/// </summary>
public class ScenarioCard : Card
{
    /// <summary>
    /// Indicates which encounter set the card belongs to.
    /// </summary>
    public string encounterSetSymbol;
    /// <summary>
    /// Indicates the number of cards within an encounter set, and this card's place within that set.
    /// </summary>
    public int encounterSetNumber;

    public ScenarioCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 场景卡
/// </summary>
public class ActCard : ScenarioCard
{
    /// <summary>
    /// Used to order the act deck.
    /// </summary>
    public int actSequence;
    /// <summary>
    /// The number of clues that must be spent to advance this act.
    /// </summary>
    public int clueThreshold;

    public ActCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 密谋卡
/// </summary>
public class AgendaCard : ScenarioCard
{
    /// <summary>
    /// Used to order the agenda deck.
    /// </summary>
    public int agendaSequence;
    /// <summary>
    /// The amount of doom in play required to advance this agenda.
    /// </summary>
    public int doomThreshold;

    public AgendaCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 地点卡
/// </summary>
public class LocationCard : ScenarioCard
{
    /// <summary>
    /// Determines the difficulty of a skill test to investigate this location.
    /// </summary>
    public int shroud;
    /// <summary>
    /// The number of clues placed on this location when it is first revealed.
    /// </summary>
    public int clueValue;
    /// <summary>
    /// Indicate the movement connections between locations.
    /// </summary>
    public string connectionSymbols;

    public bool unrevealed;

    public LocationCard(int _id, string _title) : base(_id, _title)
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

/// <summary>
/// 敌人卡
/// </summary>
public class EnemyCard : ScenarioCard
{
    /// <summary>
    /// Determines the difficulty of a skill test to attack this enemy.
    /// </summary>
    public string enemyFightValue;
    /// <summary>
    /// This enemy's health value, which measures its physical durability.
    /// </summary>
    public string enemyHealthValue;
    public string enemyHealthValueMax;
    /// <summary>
    /// Determines the difficulty of a skill test to evade this enemy.
    /// </summary>
    public string enemyEvadeValue;
    /// <summary>
    /// The amount of damage this enemy deals with its attack.
    /// </summary>
    public string damage;
    /// <summary>
    /// The amount of horror this enemy deals with its attack.
    /// </summary>
    public string horror;

    public EnemyCard(int _id, string _title) : base(_id, _title)
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
/// 玩家卡
/// </summary>
public class PlayerCard : Card
{
    /// <summary>
    /// The amount of experience required to purchase this card for a deck.
    /// </summary>
    public int level;
    /// <summary>
    /// The class to which a card belongs. Neutral cards have no class symbol.
    /// </summary>
    public string classSymbol;
    /// <summary>
    /// A secondary identifier for a card.
    /// </summary>
    public string subtitle;
    /// <summary>
    /// Modify skill value while committed to a skill test.
    /// </summary>
    public string skillTestIcons;

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
    /// This investigator's value for his or her skills, in order: Willpower, Intellect, Combat, Agility.
    /// </summary>
    public int skills;
    /// <summary>
    /// This investigator's ability for the Elder Sign token.
    /// </summary>
    public int elderSignAbility;
    /// <summary>
    /// This card's health value, which measures its physical durability.
    /// </summary>
    public int health;
    public int healthMax;
    /// <summary>
    /// This card's sanity value, which measures its mental durability.
    /// </summary>
    public int sanity;
    public int sanityMax;

    public InvestigatorCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 调查员迷你卡
/// </summary>
public class InvestigatorMiniCard : PlayerCard
{
    public InvestigatorMiniCard(int _id, string _title) : base(_id, _title)
    {

    }
}

/// <summary>
/// 支援卡
/// </summary>
public class AssetCard : PlayerCard
{
    /// <summary>
    /// The resource cost to play a card.
    /// </summary>
    public int cost;
    /// <summary>
    /// This card's health value, which measures its physical durability.
    /// </summary>
    public int health;
    public int healthMax;
    /// <summary>
    /// This card's sanity value, which measures its mental durability.
    /// </summary>
    public int sanity;
    public int sanityMax;

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
