using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Enemy/EnemySO")]
public class EnemySO : ScriptableObject
{
   
   
    [Header("Charger State")]
    public float chargeTime;
    public float chargeSpeed;
    public float checkAttackDistance;
    [Header("Patrol State")]
    public float checkDistanceGround;
    public float speed;
    [Header("Detect Player")]

    public float ledgeBehindCheckDistance;
    public float checkDistancePlayer;
    public float detectMaskPopTime;
    public float detectWaitTime;


}
