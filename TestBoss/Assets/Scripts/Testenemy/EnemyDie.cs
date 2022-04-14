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
        // 徐々に透明度を下げて0を下回ったらオブジェクト削除
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        spr.color -= new Color32(0, 0, 0, 1);
        if (spr.color.a <= 0) Destroy(gameObject);
    }
}
