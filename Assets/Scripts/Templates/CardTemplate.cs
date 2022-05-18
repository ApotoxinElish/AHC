using System;
using System.Collections.Generic;
using UnityEngine;

namespace AHC
{
    [Serializable]
    [CreateAssetMenu(
        menuName = "AHC/Templates/Card",
        fileName = "Card",
        order = 0)]
    public class CardTemplate : ScriptableObject
    {
        public int Id;
        public string Name;
        public int Cost;
        public Material Material;
        public Sprite Picture;
        public CardType Type;
        public List<Effect> Effects = new List<Effect>();
    }
}
