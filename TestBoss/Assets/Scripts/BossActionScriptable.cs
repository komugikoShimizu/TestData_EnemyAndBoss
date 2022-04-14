using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "Action", order = 1)]
public class BossActionScriptable : ScriptableObject
{
    public string actionName;
    public int damageAmount;
    public float actionTime;
    public string animationName;
}
