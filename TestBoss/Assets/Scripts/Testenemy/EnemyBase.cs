using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour,IEnemyHPSender,IEnemyStateChenge
{
    [SerializeField] private int hitPoint = 100;
    [SerializeField] private int attackPoint = 100;

    // stateの皆さん
    [SerializeField] private EnemyHit hit;
    [SerializeField] private EnemyAttack attack;
    [SerializeField] private EnemyChase chase;
    [SerializeField] private EnemyMove move;
    [SerializeField] private EnemyDie die;

    // 現在のstate
    private EnemyBaseState state;

    // デバッグ用テキスト
    [SerializeField] private Text debug;

    // Start is called before the first frame update
    void Start()
    {
        // HPの参照、減少を行えるインターフェースを渡す
        hit.SenderSet(this);

        // stateの変更を行えるインターフェースを渡す
        attack.ChengerSet(this);
        chase.ChengerSet(this);
        move.ChengerSet(this);
        die.ChengerSet(this);
    }

    // Update is called once per frame
    void Update()
    {
        debug.text = $"state : {state}\nhitPoint : {hitPoint}";

        switch (state)
        {
            case EnemyBaseState.MOVE:
                if (DamageState()) return;
                move.Move();
                break;
            case EnemyBaseState.CHASE:
                if (DamageState()) return;
                chase.Chase();
                break;
            case EnemyBaseState.ATTACK:
                if (DamageState()) return;
                attack.Attack();
                break;
            case EnemyBaseState.DAMAGE:
                if (!hit.Bouncing) state = EnemyBaseState.MOVE;
                break;
            case EnemyBaseState.DIE:
                die.Die();
                break;
        }
    }

    // ダメージを受けることを確認する関数
    private bool DamageState()
    {
        if (hit.Bouncing) state = EnemyBaseState.DAMAGE;
        return hit.Bouncing;
    }

    // HPを返すインターフェース関数
    public int HitPointSend()
    {
        return hitPoint;
    }

    // HPを減らすインターフェース関数
    public void PlayerDamage(int damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0) state = EnemyBaseState.DIE;
    }

    // stateを変更するインターフェース関数
    public void StateChenge(EnemyBaseState state)
    {
        this.state = state;
    }
}
public enum EnemyBaseState
{
    MOVE,
    CHASE,
    ATTACK,
    ACTION,
    DAMAGE,
    DIE
}
