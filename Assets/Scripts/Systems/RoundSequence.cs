using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSequence : MonoBehaviour
{
    private void Initialize()
    {

    }

    private void Run()
    {
        BeginMythosPhase();
        BeginInvestigationPhase();
        BeginEnemyPhase();
        BeginUpkeepPhase();
    }

    private void BeginMythosPhase() { }
    private void BeginInvestigationPhase() { }
    private void BeginEnemyPhase() { }
    private void BeginUpkeepPhase() { }
}
