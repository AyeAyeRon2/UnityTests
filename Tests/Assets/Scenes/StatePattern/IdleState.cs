using StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class IdleState : State
    {
        public IdleState(Enemy enemy) : base(enemy) { }
        public override void Tick()
        {
            float distance = Vector3.Distance(enemy.transform.position, enemy.player.transform.position);

            if (distance < 7f)
            {
                enemy.SetState(new AlertState(enemy));
            }
        }
        public override void OnStateEnter()
        {
            Debug.Log("Entering Idle State");
            enemy.GetComponent<Renderer>().material.color = Color.green;
        }
        public override void OnStateExit()
        {
            Debug.Log("Exiting Idle State");
        }
    }
}
