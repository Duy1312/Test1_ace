using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStateOcSen : IState
{
    float timer;
    public void OnEnter(Enemy enemy)
    {
        timer = 0;
    if(enemy.target != null)
        {
            enemy.ChangeDirection(enemy.target);
            enemy.ApplyDoubleMove();
        }
    }

    public void OnExcute(Enemy enemy)
    {
        if(timer >= 1f)
        {
            enemy.ChangeState(new PatrolStateOcSen());
        }
    }

    public void OnExit(Enemy enemy)
    {
    }

 
}
