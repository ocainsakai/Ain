
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
namespace Ain.HealthSystem
{


    public class Health : IDisposable
    {
        private HealthComponent _health;
        private CompositeDisposable _disposables = new CompositeDisposable();

        // Events
        public Subject<DamageInfo> OnDamageTaken = new Subject<DamageInfo>();
        public Subject<HealInfo> OnHealed = new Subject<HealInfo>();
        public Subject<Unit> OnDeath = new Subject<Unit>();

        // Resistances
        public Dictionary<DamageType, float> Resistances = new Dictionary<DamageType, float>();

   

        public Health(HealthComponent healthComponent)
        {
            _health = healthComponent;

            // Tự động xử lý death
            _health.CurrentHP
                .Where(hp => hp <= 0)
                .Subscribe(_ => OnDeath.OnNext(Unit.Default))
                .AddTo(_disposables);
        }
        public void Heal(float amount)
        {
            if (_health.CurrentHP.Value <= 0) return;
            // Hồi máu không vượt quá MaxHP
            _health.CurrentHP.Value = Mathf.Min(_health.MaxHP.Value, _health.CurrentHP.Value + amount);
            // Phát sự kiện
            OnHealed.OnNext(new HealInfo { Amount = amount });
        }
        public void TakeDamage(float amount, DamageType type)
        {
            Debug.Log($"Taking damage: {amount} of type {type}");
            if (_health.CurrentHP.Value <= 0) return;

            // Tính toán kháng giáp
            float resistance = Resistances.ContainsKey(type) ? Resistances[type] : 0f;
            float finalDamage = amount * (1f - resistance);

            // Ưu tiên trừ shield trước
            if (_health.Shield.Value > 0)
            {
                float remainingShield = Mathf.Max(0, _health.Shield.Value - finalDamage);
                finalDamage = Mathf.Max(0, finalDamage - _health.Shield.Value);
                _health.Shield.Value = remainingShield;
            }

            // Trừ máu
            _health.CurrentHP.Value -= finalDamage;

            // Phát sự kiện
            OnDamageTaken.OnNext(new DamageInfo(finalDamage, type));
        }

      

        public void Dispose() => _disposables.Dispose();
    }

    // Data structs
    public struct DamageInfo { 
        public float Amount; 
        public DamageType Type;

        public DamageInfo(float finalDamage, DamageType type) : this()
        {
            this.Amount = finalDamage;
            Type = type;
        }
    }
    public struct HealInfo { public float Amount; }
}