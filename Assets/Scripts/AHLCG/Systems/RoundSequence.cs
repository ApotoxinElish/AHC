using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AHLCG
{
    public class RoundSequence : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        private FirstGameSetup firstGameSetup;
        [SerializeField]
        private ScenarioSetup scenarioSetup;
        [SerializeField]
        private RoundSequence roundSequence;
#pragma warning restore 649

        public void Initialize()
        {

        }

        private void BeginMythosPhase() { }

        private void BeginInvestigationPhase() { }

        private void BeginEnemyPhase() { }

        private void BeginUpkeepPhase() { }
    }
}
