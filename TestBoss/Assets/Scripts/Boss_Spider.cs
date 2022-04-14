using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Boss_Spider : BossBase
{
    [SerializeField] private BossBehaviorRoutine routine1;
    [SerializeField] private BossBehaviorRoutine routine2;

    [SerializeField] private float actChengePer = 50;
    [SerializeField] private float downTime;

    private int routineNumber = 0;
    private float timeCount_down;

    private BossActiveState activeState;
    private state_sp State_Sp;
    private Animator animator;

    [SerializeField] private Text debugText;
    [SerializeField] private Text debugText2;
    int debugCount;
    // Start is called before the first frame update
    void Start()
    {
        if (!routine1 || !routine2) Debug.LogError("routine is Null");

        state = State.IDLE;
        
        nowHitPoint = baseHitPoint;
        State_Sp = state_sp.ROUTINE1;

        activeState = GetComponent<BossActiveState>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        debugText.text = $"state : {state}\nhitPoint : {nowHitPoint}\nroutine : {State_Sp}";

        switch (state)
        {
            case State.IDLE:
                IdleState();
                break;
            case State.ACTIVE:
                ActiveState();
                break;
            case State.DOWN:
                DownState();
                break;
            case State.DEAD:
                DeadState();
                break;
            case State.NONE:
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(5);
        }
    }

    public override void Damage(int damagePoint)
    {
        nowHitPoint -= damagePoint;
        if (nowHitPoint <= 0)
        {
            state = State.DEAD;
            State_Sp = state_sp.DEAD;
            animator.Play("Animation4");
            return;
        }
        if (activeState.GurdFlg)
        {
            state = State.DOWN;
            debugCount++;
            debugText2.text = $"‚Í‚¶‚¢‚½‰ñ” : {debugCount}";
            timeCount_down = downTime;
            activeState.justGurd();
        }
        if (nowHitPoint < actChengePer && State_Sp == state_sp.ROUTINE1)
        {
            activeState.StateActiveate(routine2);
            State_Sp = state_sp.ROUTINE2;
        }
    }

    protected override void IdleState()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            state = State.ACTIVE;
            activeState.StateActiveate(routine1);
        }
    }

    protected override void ActiveState()
    {
        activeState.ActiveState();
    }

    protected override void DownState()
    {
        if (timeCount_down > 0) timeCount_down -= Time.deltaTime;
        else
        {
            state = State.ACTIVE;
            activeState.ActionChenge();
        }
    }

    protected override void DeadState()
    {

    }

    protected enum state_sp
    {
        ROUTINE1,
        ROUTINE2,
        DEAD
    }
}
