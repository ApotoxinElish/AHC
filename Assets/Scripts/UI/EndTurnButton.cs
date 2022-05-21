using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AHC
{
    public class EndTurnButton : MonoBehaviour
    {
        private Button button;

        private HandPresentationSystem handPresentationSystem;
        // private CardWithArrowSelectionSystem cardWithArrowSelectionSystem;
        // private CardWithoutArrowSelectionSystem cardWithoutArrowSelectionSystem;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        private void Start()
        {
            handPresentationSystem = FindObjectOfType<HandPresentationSystem>();
            // cardWithArrowSelectionSystem = FindObjectOfType<CardWithArrowSelectionSystem>();
            // cardWithoutArrowSelectionSystem = FindObjectOfType<CardWithoutArrowSelectionSystem>();
        }

        public void OnButtonPressed()
        {
            if (handPresentationSystem.IsAnimating())
            {
                return;
            }

            // if (cardWithArrowSelectionSystem.HasSelectedCard() ||
            //     cardWithoutArrowSelectionSystem.HasSelectedCard())
            // {
            //     return;
            // }

            button.interactable = false;

            var system = GameObject.FindObjectOfType<TurnManagementSystem>();
            system.EndPlayerTurn();
        }

        public void OnPlayerTurnBegan()
        {
            button.interactable = true;
        }
    }
}
