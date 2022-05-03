using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public TextAsset cardData;
    public Dictionary<int, Card> cardDict = new Dictionary<int, Card>();

    // Start is called before the first frame update
    void Start()
    {
        //LoadCardData();
        //TestLoad();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadCardData()
    {
        string[] dataRow = cardData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "Investigator")
            {
                // 新建调查员卡
                int id = int.Parse(rowArray[1]);
                string title = rowArray[2];
                // int atk = int.Parse(rowArray[3]);
                // int health = int.Parse(rowArray[4]);
                InvestigatorCard investigatorCard = new InvestigatorCard(id, title);
                cardDict.Add(id, investigatorCard);

                Debug.Log("读取到调查员卡：" + cardDict[id].title);
            }
            else if (rowArray[0] == "Asset")
            {
                // 新建支援卡
                int id = int.Parse(rowArray[1]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                AssetCard assetCard = new AssetCard(id, title);
                cardDict.Add(id, assetCard);

                Debug.Log("读取到支援卡：" + cardDict[id].title);
            }
            else if (rowArray[0] == "Event")
            {
                // 新建支援卡
                int id = int.Parse(rowArray[1]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                EventCard eventCard = new EventCard(id, title);
                cardDict.Add(id, eventCard);

                Debug.Log("读取到支援卡：" + cardDict[id].title);
            }
            else if (rowArray[0] == "Asset")
            {
                // 新建支援卡
                int id = int.Parse(rowArray[1]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                AssetCard assetCard = new AssetCard(id, title);
                cardDict.Add(id, assetCard);

                Debug.Log("读取到支援卡：" + cardDict[id].title);
            }
            else if (rowArray[0] == "Asset")
            {
                // 新建支援卡
                int id = int.Parse(rowArray[1]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                AssetCard assetCard = new AssetCard(id, title);
                cardDict.Add(id, assetCard);

                Debug.Log("读取到支援卡：" + cardDict[id].title);
            }
            else if (rowArray[0] == "Asset")
            {
                // 新建支援卡
                int id = int.Parse(rowArray[1]);
                string title = rowArray[2];
                // string effect = rowArray[3];
                AssetCard assetCard = new AssetCard(id, title);
                cardDict.Add(id, assetCard);

                Debug.Log("读取到支援卡：" + cardDict[id].title);
            }
        }
    }

    public void TestLoad()
    {
        foreach (var item in cardDict)
        {
            Debug.Log("卡牌：" + item.Key.ToString() + item.Value.title);
        }
    }

    public Card RandomCard()
    {
        Card card = cardDict[Random.Range(0, cardDict.Count)];
        return card;
    }

    public Card CopyCard(int _id)
    {
        Card copyCard = new Card(_id, cardDict[_id].title);
        if (cardDict[_id] is InvestigatorCard)
        {
            var monstercard = cardDict[_id] as InvestigatorCard;
            copyCard = new InvestigatorCard(_id, monstercard.title);
        }
        else if (cardDict[_id] is SkillCard)
        {
            var spellcard = cardDict[_id] as SkillCard;
            copyCard = new SkillCard(_id, spellcard.title);
        }
        // 其他卡牌类型

        return copyCard;
    }
}
