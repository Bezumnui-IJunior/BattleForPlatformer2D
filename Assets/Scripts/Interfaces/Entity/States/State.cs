using Enemy.States;
using UnityEngine;

namespace Entity.States
{
    public abstract class State : MonoBehaviour
    {
        protected IStateMachine StateMachine { get; private set; }

        protected virtual void Awake()
        {
            StateMachine = GetComponent<StateMachine>();
        }

        public void Occupy()
        {
            enabled = true;
        }

        public void Exit()
        {
            enabled = false;
        }
    }
}