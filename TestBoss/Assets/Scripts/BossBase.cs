using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour
{
    [SerializeField] protected int baseHitPoint;

    protected int nowHitPoint;

    protected State state;

    public virtual void Damage(int damagePoint)
    {
        nowHitPoint -= damagePoint;

        if (nowHitPoint <= 0) state = State.DEAD;
    }

    protected virtual void IdleState()
    {

    }

    protected virtual void ActiveState()
    {

    }

    protected virtual void DownState()
    {

    }

    protected virtual void DeadState()
    {

    }

    public enum State
    {
        IDLE,
        ACTIVE,
        DOWN,
        DEAD,
        NONE
    }
}
