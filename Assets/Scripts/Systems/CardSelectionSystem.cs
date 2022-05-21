using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace AHC
{
    public class CardSelectionSystem : BaseSystem
    {
        public IntVariable PlayerMana;

        public TurnManagementSystem TurnManagementSystem;
        public DeckDrawingSystem DeckDrawingSystem;
        public HandPresentationSystem HandPresentationSystem;

        protected Camera MainCamera;
        protected LayerMask CardLayer;

        protected GameObject SelectedCard;




        private BoxCollider2D cardArea;

        private Vector3 originalCardPos;
        private Quaternion originalCardRot;
        private int originalCardSortingOrder;

        private bool isCardAboutToBePlayed;

        private const float CardAnimationTime = 0.4f;
        private const float CardAboutToBePlayedOffsetY = 1.5f;
        private const Ease CardAnimationEase = Ease.OutBack;




        protected virtual void Start()
        {
            CardLayer = 1 << LayerMask.NameToLayer("Card");
            MainCamera = Camera.main;


            var go = GameObject.Find("CardArea");
            if (go != null)
                cardArea = go.GetComponent<BoxCollider2D>();
        }

        protected virtual void PlaySelectedCard()
        {
            var cardObject = SelectedCard.GetComponent<CardObject>();
            cardObject.SetInteractable(false);
            var cardTemplate = cardObject.Template;
            PlayerMana.SetValue(PlayerMana.Value - cardTemplate.Cost);

            HandPresentationSystem.RearrangeHand(SelectedCard);
            HandPresentationSystem.RemoveCardFromHand(SelectedCard);
            HandPresentationSystem.MoveCardToDiscardPile(SelectedCard);

            DeckDrawingSystem.MoveCardToDiscardPile(cardObject.RuntimeCard);




            var card = SelectedCard.GetComponent<CardObject>().RuntimeCard;
            // EffectResolutionSystem.ResolveCardEffects(card);
        }

        public bool HasSelectedCard()
        {
            return SelectedCard != null;
        }




        private void Update()
        {
            if (TurnManagementSystem.IsEndOfGame())
                return;

            if (HandPresentationSystem.IsAnimating())
                return;

            if (isCardAboutToBePlayed)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                DetectCardSelection();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                DetectCardUnselection();
            }

            if (SelectedCard != null)
                UpdateSelectedCard();
        }

        private void DetectCardSelection()
        {
            if (SelectedCard != null)
                return;

            // Checks if the player clicked over a card.
            var mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            var hitInfo = Physics2D.Raycast(mousePos, Vector3.forward, Mathf.Infinity, CardLayer);
            if (hitInfo.collider != null)
            {
                var card = hitInfo.collider.GetComponent<CardObject>();
                var cardTemplate = card.Template;
                // if (CardUtils.CardCanBePlayed(cardTemplate, PlayerMana) &&
                //     !CardUtils.CardHasTargetableEffect(cardTemplate))
                // {
                SelectedCard = hitInfo.collider.gameObject;
                originalCardPos = SelectedCard.transform.position;
                originalCardRot = SelectedCard.transform.rotation;
                originalCardSortingOrder = SelectedCard.GetComponent<SortingGroup>().sortingOrder;
                // }
            }
        }

        private void DetectCardUnselection()
        { }

        private void UpdateSelectedCard()
        {
            if (Input.GetMouseButtonUp(0))
            {
                var card = SelectedCard.GetComponent<CardObject>();
                if (card.State == CardObject.CardState.AboutToBePlayed)
                {
                    isCardAboutToBePlayed = true;

                    var seq = DOTween.Sequence();
                    seq.Append(SelectedCard.transform
                        .DOMove(cardArea.bounds.center, CardAnimationTime)
                        .SetEase(CardAnimationEase));
                    seq.AppendInterval(CardAnimationTime + 0.1f);
                    seq.AppendCallback(() =>
                    {
                        PlaySelectedCard();
                        SelectedCard = null;
                        isCardAboutToBePlayed = false;
                    });
                    SelectedCard.transform.DORotate(Vector3.zero, CardAnimationTime);
                }
                else
                {
                    card.SetState(CardObject.CardState.InHand);
                    SelectedCard.GetComponent<CardObject>().Reset(() => SelectedCard = null);
                }
            }

            if (SelectedCard != null)
            {
                var mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                SelectedCard.transform.position = mousePos;

                var card = SelectedCard.GetComponent<CardObject>();
                if (mousePos.y > originalCardPos.y + CardAboutToBePlayedOffsetY)
                    card.SetState(CardObject.CardState.AboutToBePlayed);
                else
                    card.SetState(CardObject.CardState.InHand);
            }
        }
    }
}
