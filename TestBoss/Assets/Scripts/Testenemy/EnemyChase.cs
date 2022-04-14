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
        // �{���̋����͈�莞�Ԍ�ɍU���ɕω�
        if (Input.GetKeyDown(KeyCode.Return)) stateChenge.StateChenge(EnemyBaseState.ATTACK);
    }
}
