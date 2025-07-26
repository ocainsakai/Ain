using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Ain.HealthSystem
{
    public class HealthModifier : IDisposable
    {
        public string ID;
        public DamageType Type;
        public float ValuePerTick; // Sát thương/hồi máu mỗi tick
        public float Duration;
        public float TickInterval;

        private float _elapsedTime;
        private float _nextTickTime;

        private CompositeDisposable _disposables = new CompositeDisposable();

        // Các hiệu ứng đang active (DOT, HOT...)
        public List<HealthModifier> ActiveModifiers = new List<HealthModifier>();

        public void ApplyModifier(HealthModifier modifier)
        {
            ActiveModifiers.Add(modifier);

            // Tự động hủy sau duration
            Observable.Timer(TimeSpan.FromSeconds(modifier.Duration))
                .Subscribe(_ => ActiveModifiers.Remove(modifier))
                .AddTo(_disposables);
        }
        public void Update(Health health, float deltaTime)
        {
            _elapsedTime += deltaTime;

            // Áp dụng hiệu ứng theo chu kỳ (DOT/HOT)
            if (_elapsedTime >= _nextTickTime)
            {
                ApplyEffect(health);
                _nextTickTime += TickInterval;
            }

            // Tự động hủy khi hết thời gian
            if (_elapsedTime >= Duration)
            {

                //health.(this);
            }
        }

        private void ApplyEffect(Health health)
        {
            if (ValuePerTick > 0)
            {
                health.Heal(ValuePerTick); // Heal
            }
            else
            {
                health.TakeDamage(Mathf.Abs(ValuePerTick), Type); // Damage
            }
        }

        public void Dispose() => _disposables.Dispose();

    }
}