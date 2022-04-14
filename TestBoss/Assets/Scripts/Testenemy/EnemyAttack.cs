using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    IEnemyStateChenge stateChenge;

    public void ChengerSet(IEnemyStateChenge chenger)
    {
        stateChenge = chenger;
    }

    public void Attack()
    {
        // ¡‰ñ‚Í‰¼‚ÉˆÚ“®‚É•Ï‰»
        if (Input.GetKeyDown(KeyCode.Return)) stateChenge.StateChenge(EnemyBaseState.MOVE);
    }
}
