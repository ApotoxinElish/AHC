using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GamePhase
{
    mythosPhase, investigationPhase, enemyPhase, upkeepPhase
}

public class RoundManager : MonoSingleton<RoundManager>
{
    public PlayerData playerData;
    public PlayerData enemyData;//数据

    public List<Card> playerDeckList = new List<Card>();
    public List<Card> enemyDeckList = new List<Card>();// 卡组

    public GamePhase GamePhase = GamePhase.investigationPhase;

    public UnityEvent phaseChangeEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //游戏流程
    //开始游戏：加载数据，卡组洗牌，初始手牌
    //回合结束，游戏阶段
    public void GameStart()
    {
        // 读取数据
        ReadDeck();

        // 卡组洗牌
        ShuffleDeck(0);

        // 玩家抽卡5，敌人抽卡5
        DrawCard(0, 3);
    }

    public void ReadDeck()
    {
        // 加载玩家卡组
        for (int i = 0; i < playerData.playerDeck.Count; i++)
        {
            // if (playerData.playerDeck[i] != 0)
            // {
            //     int count = playerData.playerDeck[i];
            //     for (int j = 0; j < count; j++)
            //     {
            //         playerDeckList.Add(playerData.CardStore.CopyCard(i));
            //     }
            // }
        }

        // 加载敌人卡组
        for (int i = 0; i < enemyData.playerDeck.Count; i++)
        {
            // if (enemyData.playerDeck[i] != 0)
            // {
            //     int count = enemyData.playerDeck[i];
            //     for (int j = 0; j < count; j++)
            //     {
            //         enemyDeckList.Add(enemyData.CardStore.CopyCard(i));
            //     }
            // }
        }
    }

    public void ShuffleDeck(int _player)// 0为玩家，1为敌人
    {

    }

    public void DrawCard(int _player, int _count)
    {

    }

    public void OnClickTurnEnd()
    {
        TurnEnd();
    }

    public void TurnEnd()
    {
        if (GamePhase == GamePhase.investigationPhase)
        {
            NextPhase();
        }
    }

    public void NextPhase()
    {
        if ((int)GamePhase == System.Enum.GetNames(GamePhase.GetType()).Length - 1)
        {
            GamePhase = GamePhase.investigationPhase;
        }
        else
        {
            GamePhase += 1;
        }
        phaseChangeEvent.Invoke();
    }
}
