using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.AddressableAssets;

namespace AHC
{
    public class GameBootstrap : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private DeckDrawingSystem deckDrawingSystem;
        [SerializeField]
        private HandPresentationSystem handPresentationSystem;
        [SerializeField]
        private TurnManagementSystem turnManagementSystem;
        [SerializeField]
        private EffectResolutionSystem effectResolutionSystem;

        [SerializeField]
        private ResourceWidget resourceWidget;
        [SerializeField]
        private DeckWidget deckWidget;
        [SerializeField]
        private DiscardPileWidget discardPileWidget;

        [SerializeField]
        private ObjectPool handPool;
        [SerializeField]
        private ObjectPool AssetPool;
        [SerializeField]
        private ObjectPool ThreatPool;
        [SerializeField]
        private ObjectPool deckPool;
        [SerializeField]
        private ObjectPool DiscardPool;
#pragma warning restore 649

        private Camera mainCamera;

        [SerializeField]
        private CardLibrary playerDeck;

        void Start()
        {
            mainCamera = Camera.main;

            handPool.Initialize();

            var mana = ScriptableObject.CreateInstance<IntVariable>(); // playerConfig.Mana;
            mana.Value = 3;

            // playerDeck = template.StartingDeck;
            resourceWidget.Initialize(mana);

            InitializeGame();
        }

        private void InitializeGame()
        {
            deckDrawingSystem.Initialize(deckWidget, discardPileWidget);
            var deckSize = deckDrawingSystem.LoadDeck(playerDeck);
            deckDrawingSystem.ShuffleDeck();

            handPresentationSystem.Initialize(handPool, deckWidget, discardPileWidget);

            // effectResolutionSystem.Initialize(playerCharacter, enemyCharacter);

            turnManagementSystem.BeginGame();
        }
    }
}
