using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHC
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField]
        private DeckDrawingSystem deckDrawingSystem;
        [SerializeField]
        private HandPresentationSystem handPresentationSystem;
        [SerializeField]
        private TurnManagementSystem turnManagementSystem;


        [SerializeField]
        private DeckWidget deckWidget;
        [SerializeField]
        private DiscardPileWidget discardPileWidget;

        [SerializeField]
        private ObjectPool cardPool;

        private Camera mainCamera;

        private CardLibrary playerDeck;

        void Start()
        {
            mainCamera = Camera.main;

            cardPool.Initialize();
        }

        private void InitializeGame()
        {
            deckDrawingSystem.Initialize(deckWidget, discardPileWidget);
            var deckSize = deckDrawingSystem.LoadDeck(playerDeck);
            deckDrawingSystem.ShuffleDeck();

            handPresentationSystem.Initialize(cardPool, deckWidget, discardPileWidget);

            // effectResolutionSystem.Initialize(playerCharacter, enemyCharacter);

            turnManagementSystem.BeginGame();
        }
    }
}
