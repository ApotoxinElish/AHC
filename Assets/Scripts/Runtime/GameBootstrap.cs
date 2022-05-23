using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHC
{
    public class GameBootstrap : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private PlayableCharacterConfiguration playerConfig;

        [SerializeField]
        private DeckDrawingSystem deckDrawingSystem;
        [SerializeField]
        private HandPresentationSystem handPresentationSystem;
        [SerializeField]
        private TurnManagementSystem turnManagementSystem;
        [SerializeField]
        private EffectResolutionSystem effectResolutionSystem;

        [SerializeField]
        private PlayerTemplate characterTemplate;

        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private ResourceWidget resourceWidget;
        [SerializeField]
        private DeckWidget deckWidget;
        [SerializeField]
        private DiscardPileWidget discardPileWidget;
        [SerializeField]
        private EndTurnButton endTurnButton;

        [SerializeField]
        private ObjectPool handPool;
        [SerializeField]
        private ObjectPool assetPool;
        [SerializeField]
        private ObjectPool threatPool;
        [SerializeField]
        private ObjectPool deckPool;
        [SerializeField]
        private ObjectPool discardPool;
#pragma warning restore 649

        private Camera mainCamera;

        private CardLibrary playerDeck;

        private GameObject player;

        void Start()
        {
            mainCamera = Camera.main;

            handPool.Initialize();

            CreatePlayer(characterTemplate);
        }

        private void CreatePlayer(PlayerTemplate template)
        {
            // player = Instantiate(template.Prefab, playerPivot);
            // Assert.IsNotNull(player);

            playerDeck = template.StartingDeck;

            var health = playerConfig.Health;
            var resource = playerConfig.Resource;
            health.Value = template.Health;
            resource.Value = template.Resource;

            // playerDeck = template.StartingDeck;
            // healthWidget.Initialize(health);
            resourceWidget.Initialize(resource);

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
