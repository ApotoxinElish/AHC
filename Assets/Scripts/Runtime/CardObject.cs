// using DG.Tweening;
using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace AHC
{
    /// <summary>
    /// This component is linked to the actual GameObjects corresponding to the cards that
    /// are in the player's hand.
    /// </summary>
    public class CardObject : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro costText;
        [SerializeField]
        private TextMeshPro nameText;
        [SerializeField]
        private TextMeshPro typeText;
        [SerializeField]
        private TextMeshPro descriptionText;

        [SerializeField]
        private SpriteRenderer picture;
        [SerializeField]
        private SpriteRenderer glow;

        public RuntimeCard RuntimeCard;
        public CardTemplate Template;

        private Vector3 cachedPos;
        private Quaternion cachedRot;

        private bool interactable;

        public void SetInfo(RuntimeCard card)
        {
            RuntimeCard = card;
            Template = card.Template;
            costText.text = Template.Cost.ToString();
            nameText.text = Template.Name;
            typeText.text = "Spell";
            var builder = new StringBuilder();
            foreach (var effect in Template.Effects)
            {
                builder.AppendFormat("{0}. ", effect.GetName());
            }
            descriptionText.text = builder.ToString();
            picture.material = Template.Material;
            picture.sprite = Template.Picture;
        }

        public void SetGlowEnabled(int playerMana)
        {
            glow.enabled = playerMana >= Template.Cost;
        }

        public void SetInteractable(bool value)
        {
            interactable = value;
        }

        public void CacheTransform(Vector3 position, Quaternion rotation)
        {
            cachedPos = position;
            cachedRot = rotation;
            // cachedSortingOrder = sortingGroup.sortingOrder;
            // highlightedSortingOrder = cachedSortingOrder + 10;
        }

        public void UnHighlightCard()
        {

        }
    }
}
