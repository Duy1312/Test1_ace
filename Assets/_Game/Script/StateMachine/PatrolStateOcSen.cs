using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolStateOcSen : IState
{
    float timer = 0;
    float randomTimer;
    public void OnEnter(Enemy enemy)
    {
        randomTimer = Random.Range(5,10);
    }

    public void OnExcute(Enemy enemy)
    {
      if(timer > randomTimer)
        {
            enemy.ChangeState(new IdleStateOcSen());
        }
        timer += Time.deltaTime;
    }

    public void OnExit(Enemy enemy)
    {
        
    }


}
