using TMPro;
using UnityEngine;

namespace AHC
{
    /// <summary>
    /// The widget used to display the player's sanity.
    /// </summary>
    public class SanityWidget : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private TextMeshProUGUI text;
        // [SerializeField]
        // private TextMeshProUGUI textBorder;
#pragma warning restore 649

        private int maxValue;

        public void Initialize(IntVariable sanity)
        {
            maxValue = sanity.Value;
            SetValue(sanity.Value);
        }

        private void SetValue(int value)
        {
            text.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }

        public void OnSanityChanged(int value)
        {
            SetValue(value);
        }
    }
}
