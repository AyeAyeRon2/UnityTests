using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StatePattern
{
    public class Enemy : MonoBehaviour
    {
        public GameObject player;

        private State currentState;

        // Start is called before the first frame update
        void Start()
        {
            currentState = new IdleState(this);
        }

        // Update is called once per frame
        void Update()
        {
            currentState.Tick();
        }

        public void SetState(State state)
        {
            currentState.OnStateExit();
            currentState = state;
            currentState.OnStateEnter();
        }
    }
}
