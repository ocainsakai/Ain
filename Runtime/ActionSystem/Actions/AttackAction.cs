
namespace Ain.ActionSystem.Actions
{
    using System;
    using UniRx;
    using UnityEngine;
    public class AttackAction : ActionState
    {
        public override ActionStateType Type => ActionStateType.Attacking;
        private readonly ActionController _controller;
        private int damage;
        private Health target;
        public AttackAction(ActionController controller, Health target, int dame)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            this.target = target ?? throw new ArgumentException(nameof(target));
            damage = dame > 0 ? dame : throw new ArgumentOutOfRangeException(nameof(dame), "Damage must be greater than zero.");
        }
        public override void OnEnter()
        {
            Debug.Log("Entering Attack State");
            // Logic to initiate attack
            // For example, play an animation or sound
            target.TakeDamage(damage, DamageType.Physical); // Example damage value

        }
        public override void Tick()
        {
            // Logic to handle attack updates
            // For example, check if the attack is complete
        }
        public override void OnExit()
        {
            Debug.Log("Exiting Attack State");
            // Logic to clean up after the attack
            _controller.OnActionCompleted.OnNext(Unit.Default);
        }
    }
}