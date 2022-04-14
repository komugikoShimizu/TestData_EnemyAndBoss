using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    IEnemyStateChenge stateChenge;

    public void ChengerSet(IEnemyStateChenge chenger)
    {
        stateChenge = chenger;
    }

    public void Die()
    {
        // ���X�ɓ����x��������0�����������I�u�W�F�N�g�폜
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        spr.color -= new Color32(0, 0, 0, 1);
        if (spr.color.a <= 0) Destroy(gameObject);
    }
}
