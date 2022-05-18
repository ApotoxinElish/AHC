using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AHC
{
    /// <summary>
    /// This system is responsible for managing the visual state and animations of the card
    /// game objects in the player's hand.
    /// </summary>
    public class HandPresentationSystem : MonoBehaviour
    {
        public IntVariable playerMana;

        private ObjectPool cardPool;
        private DeckWidget deckWidget;
        private DiscardPileWidget discardPileWidget;

        private readonly List<GameObject> handCards = new List<GameObject>(PositionsCapacity);

        private bool isAnimating;

        private List<Vector3> positions;
        private List<Quaternion> rotations;
        private List<int> sortingOrders;

        private const int PositionsCapacity = 30;
        private const int RotationsCapacity = 30;
        private const int SortingOrdersCapacity = 30;

        private const float CenterRadius = 16.0f;
        private readonly Vector3 centerPoint = new Vector3(0.0f, -20.5f, 0.0f);
        private readonly Vector3 originalCardScale = new Vector3(0.6f, 0.6f, 1.0f);

        public static float CardToDiscardPileAnimationTime = 0.3f;

        public void Initialize(ObjectPool pool, DeckWidget deck, DiscardPileWidget discardPile)
        {
            cardPool = pool;
            deckWidget = deck;
            discardPileWidget = discardPile;
        }

        private void Start()
        {
            positions = new List<Vector3>(PositionsCapacity);
            rotations = new List<Quaternion>(RotationsCapacity);
            sortingOrders = new List<int>(SortingOrdersCapacity);
        }

        public void CreateCardsInHand(List<RuntimeCard> hand, int deckSize)
        {
            var drawnCards = new List<GameObject>(hand.Count);
            foreach (var card in hand)
            {
                var go = CreateCardGo(card);
                handCards.Add(go);
                drawnCards.Add(go);
            }

            deckWidget.SetAmount(deckSize);

            AnimateCardsFromDeckToHand(drawnCards);
        }

        public void UpdateDiscardPileSize(int size)
        {
            discardPileWidget.SetAmount(size);
        }

        public bool IsAnimating()
        {
            return isAnimating;
        }

        private GameObject CreateCardGo(RuntimeCard card)
        {
            var go = cardPool.GetObject();
            var obj = go.GetComponent<CardObject>();
            obj.SetInfo(card);
            obj.SetGlowEnabled(playerMana.Value);
            go.transform.position = deckWidget.transform.position;
            go.transform.localScale = Vector3.zero;

            return go;
        }

        private void AnimateCardsFromDeckToHand(List<GameObject> drawnCards)
        {

        }

        private void ArrangeHandCards()
        {
            positions.Clear();
            rotations.Clear();
            sortingOrders.Clear();

            const float angle = 5.0f;
            var cardAngle = (handCards.Count - 1) * angle / 2;
            var z = 0.0f;
            for (var i = 0; i < handCards.Count; ++i)
            {
                // Rotate.
                var rotation = Quaternion.Euler(0, 0, cardAngle - i * angle);
                rotations.Add(rotation);

                // Move.
                z -= 0.1f;
                var position = CalculateCardPosition(cardAngle - i * angle);
                position.z = z;
                positions.Add(position);

                // Set sorting order.
                sortingOrders.Add(i);
            }
        }

        public void RearrangeHand(GameObject selectedCard)
        {
            handCards.Remove(selectedCard);
        }

        public void RemoveCardFromHand(GameObject go)
        {
            handCards.Remove(go);
        }

        public void MoveCardToDiscardPile(GameObject go)
        {

        }

        public void MoveHandToDiscardPile()
        {
            foreach (var card in handCards)
                MoveCardToDiscardPile(card);
            handCards.Clear();
        }

        private Vector3 CalculateCardPosition(float angle)
        {
            return new Vector3(
                centerPoint.x - CenterRadius * Mathf.Sin(Mathf.Deg2Rad * angle),
                centerPoint.y + CenterRadius * Mathf.Cos(Mathf.Deg2Rad * angle),
                0.0f);
        }

        public void UnHighlightOtherCards(GameObject x)
        {
            foreach (var card in handCards)
            {
                if (card != x)
                {
                    // card.GetComponent<CardObject>().UnHighlightCard();
                }
            }
        }
    }
}
