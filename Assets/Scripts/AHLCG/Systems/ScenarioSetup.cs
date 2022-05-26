using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public class ScenarioSetup : MonoBehaviour
    {
        public void Initialize()
        {
            GatherScenarioCards();
            SetAgendaDeck();
            SetActDeck();
            PlaceReferenceCard();
            PlaceLocations();
            AssembleEncounterDeck();
            ReadScenarioIntroduction();
            PlaceInvestigators();
        }

        private void GatherScenarioCards() { }

        private void SetAgendaDeck() { }

        private void SetActDeck() { }

        private void PlaceReferenceCard() { }

        private void PlaceLocations() { }

        private void AssembleEncounterDeck() { }

        private void ReadScenarioIntroduction() { }

        private void PlaceInvestigators() { }
    }
}
