using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class AttackState : State
    {
        public AttackState(Enemy enemy) : base(enemy) { }
        public override void Tick()
        {
            float distance = Vector3.Distance(enemy.transform.position, enemy.player.transform.position);

            if (distance > 4f)
            {
                enemy.SetState(new AlertState(enemy));
            }
        }
        public override void OnStateEnter()
        {
            Debug.Log("Entering Attack State");
            enemy.GetComponent<Renderer>().material.color = Color.red;
        }
        public override void OnStateExit()
        {
            Debug.Log("Exiting Attack State");
        }
    }
}
