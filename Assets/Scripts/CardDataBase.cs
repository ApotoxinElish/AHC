using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None", Resources.Load<Sprite>("0")));
        cardList.Add(new Card(1, "Elf", 2, 1000, "It's Elf", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(2, "Dwarf", 3, 3000, "It's Dwarf", Resources.Load<Sprite>("2")));
        cardList.Add(new Card(3, "Human", 5, 6000, "It's Human", Resources.Load<Sprite>("3")));
        cardList.Add(new Card(4, "Demon", 1, 1000, "It's Demon", Resources.Load<Sprite>("4")));
    }
}
