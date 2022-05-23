using UnityEngine;

namespace AHC
{
    [CreateAssetMenu(
        menuName = "AHC/Configuration/Player character",
        fileName = "PCConfiguration",
        order = 0)]
    public class PlayableCharacterConfiguration : ScriptableObject
    {
        public IntVariable Hp;
        public IntVariable Shield;

        public IntVariable Resource;

        // public StatusVariable Status;

        public GameObject HpWidget;
        public GameObject StatusWidget;
    }
}
