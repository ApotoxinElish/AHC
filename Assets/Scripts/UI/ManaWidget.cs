using TMPro;
using UnityEngine;

namespace AHC
{
    /// <summary>
    /// The widget used to display the player's mana.
    /// </summary>
    public class ManaWidget : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private TextMeshProUGUI textBorder;

        private int maxValue;

        public void Initialize(IntVariable mana)
        {
            maxValue = mana.Value;
            SetValue(mana.Value);
        }

        private void SetValue(int value)
        {
            text.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            textBorder.text = text.text;
        }

        public void OnManaChanged(int value)
        {
            SetValue(value);
        }
    }
}
