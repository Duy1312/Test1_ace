using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateOcSen : IState
{
    float time;
    float randomTime;
    public void OnEnter(Enemy enemy)
    {
        time = 0;
        randomTime = Random.Range(1, 3);
        enemy.StopMoving();
    }

    public void OnExcute(Enemy enemy)
    {
      if(time > randomTime)
        {
            enemy.ChangeState(new IdleStateOcSen());
        }
        time += Time.deltaTime;
    }

    public void OnExit(Enemy enemy)
    {
       
    }

   
}
