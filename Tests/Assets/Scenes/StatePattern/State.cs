using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public abstract class State
    {
        protected Enemy enemy;

        public State(Enemy enemy)
        {
            this.enemy = enemy;
        }

        // abstract methods must be given definition (overriden) in derived classes
        public abstract void Tick();

        // virtual methods may be given definition (overriden) in derived classes
        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }
    }
}
