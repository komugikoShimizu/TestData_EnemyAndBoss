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
        // 今回は仮に移動に変化
        if (Input.GetKeyDown(KeyCode.Return)) stateChenge.StateChenge(EnemyBaseState.MOVE);
    }
}
