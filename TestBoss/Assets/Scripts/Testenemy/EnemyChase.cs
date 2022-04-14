using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    IEnemyStateChenge stateChenge;

    public void ChengerSet(IEnemyStateChenge chenger)
    {
        stateChenge = chenger;
    }

    public void Chase()
    {
        // –{—ˆ‚Ì‹““®‚Íˆê’èŠÔŒã‚ÉUŒ‚‚É•Ï‰»
        if (Input.GetKeyDown(KeyCode.Return)) stateChenge.StateChenge(EnemyBaseState.ATTACK);
    }
}
