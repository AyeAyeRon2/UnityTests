using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class AlertState : State
    {
        public AlertState(Enemy enemy) : base(enemy) { }
        public override void Tick()
        {
            float distance = Vector3.Distance(enemy.transform.position, enemy.player.transform.position);

            if (distance < 4f)
            {
                enemy.SetState(new AttackState(enemy));
            }
            else if (distance > 7f)
            {
                enemy.SetState(new IdleState(enemy));
            }
        }
        public override void OnStateEnter()
        {
            Debug.Log("Entering Alert State");
            enemy.GetComponent<Renderer>().material.color = Color.yellow;
        }
        public override void OnStateExit()
        {
            Debug.Log("Exiting Alert State");
        }
    }
}
