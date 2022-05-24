using TMPro;
using UnityEngine;

namespace AHC
{
    /// <summary>
    /// The widget used to display the player's resource.
    /// </summary>
    public class ResourceWidget : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private TextMeshProUGUI text;
        // [SerializeField]
        // private TextMeshProUGUI textBorder;
#pragma warning restore 649

        // private int maxValue;

        public void Initialize(IntVariable resource)
        {
            // maxValue = resource.Value;
            SetValue(resource.Value);
        }

        private void SetValue(int value)
        {
            text.text = $"{value.ToString()}"; // /{maxValue.ToString()}";
            // textBorder.text = text.text;
        }

        public void OnResourceChanged(int value)
        {
            SetValue(value);
        }
    }
}
