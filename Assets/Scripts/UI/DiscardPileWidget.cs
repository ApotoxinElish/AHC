using TMPro;
using UnityEngine;

namespace AHC
{
    public class DiscardPileWidget : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textLabel;

        private int discardPileSize;

        public void SetAmount(int amount)
        {
            discardPileSize = amount;
            textLabel.text = amount.ToString();
        }

        public void AddCard()
        {
            SetAmount(discardPileSize + 1);
        }
    }
}
