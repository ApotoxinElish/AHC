using System;
using UnityEngine;

namespace AHC
{
    [Serializable]
    [CreateAssetMenu(
        menuName = "AHC/Templates/Player",
        fileName = "Player",
        order = 1)]
    public class PlayerTemplate : CharacterTemplate
    {
        public int Health;
        public int Resource;
        public CardLibrary StartingDeck;
    }
}
