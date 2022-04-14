using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Routine", menuName = "Routine", order = 1)]
public class BossBehaviorRoutine : ScriptableObject
{
    public List<BossActionScriptable> routine;
}
