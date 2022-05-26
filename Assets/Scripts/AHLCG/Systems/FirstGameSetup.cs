using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public class FirstGameSetup : MonoBehaviour
    {
        public void Initialize()
        {
            ChooseInvestigators();
            GatherDecks();
            ChooseLeadInvestigator();
            AssembleTokenPool();
            AssembletheChaosBag();
            TakeStartingResources();
            DrawOpeningHand();
        }

        private void ChooseInvestigators() { }

        private void GatherDecks() { }

        private void ChooseLeadInvestigator() { }

        private void AssembleTokenPool() { }

        private void AssembletheChaosBag() { }

        private void TakeStartingResources() { }

        private void DrawOpeningHand() { }
    }
}
