using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    IEnemyStateChenge stateChenge;

    public void ChengerSet(IEnemyStateChenge chenger)
    {
        stateChenge = chenger;
    }

    public void Move()
    {
        // 本来の挙動は探索オブジェクトからtrueがきたら追跡に変化
        if (Input.GetKeyDown(KeyCode.Return)) stateChenge.StateChenge(EnemyBaseState.CHASE);
    }
}
