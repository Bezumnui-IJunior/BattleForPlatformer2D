using Enemy.States;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Entity.Entity))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;

        private Entity.Entity _entity;
        public IRotator Rotator => _entity.Rotator;
        
    }
}