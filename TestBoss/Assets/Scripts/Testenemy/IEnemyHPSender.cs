using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHPSender
{
    int HitPointSend();
    void PlayerDamage(int damage);
}
