using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BossActiveState : MonoBehaviour
{
    private int routineNumber = 0;
    private float timeCount_action;
    private bool gurdFlg;

    private BossBehaviorRoutine routine;
    private Animator animator;

    [SerializeField] private Text debugText;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StateActiveate(BossBehaviorRoutine newRoutine)
    {
        routine = newRoutine;
        routineNumber = -1;
        ActionChenge();
    }

    public void ActiveState()
    {
        if (timeCount_action > 0) timeCount_action -= Time.deltaTime;
        else ActionChenge();
    }

    public void ActionChenge()
    {
        routineNumber = routineNumber >= routine.routine.Count - 1 ? 0 : routineNumber+1;
        timeCount_action = routine.routine[routineNumber].actionTime;
        gurdFlg = false;
        if (routine.routine[routineNumber].animationName != null) animator.Play(routine.routine[routineNumber].animationName);
        debugText.text = $"active action : {routine.routine[routineNumber].actionName}\n";
    }

    public void justGurd()
    {
        gurdFlg = gurdFlg ? false : true;
    }

    public bool GurdFlg
    {
        get
        {
            if (gurdFlg) animator.Play("Animation3");
            return gurdFlg;
        }
    }
}
