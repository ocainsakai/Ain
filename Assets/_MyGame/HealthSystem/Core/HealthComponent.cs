using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
namespace Ain.HealthSystem
{
    public class HealthComponent : MonoBehaviour
    {
        public ReactiveProperty<float> CurrentHP = new ReactiveProperty<float>();
        public ReactiveProperty<float> MaxHP = new ReactiveProperty<float>();
        public ReactiveProperty<float> Shield = new ReactiveProperty<float>();

        // Kháng giáp (Fire, Poison, Physical...)
        void Start()
        {
            MaxHP.Pairwise().Subscribe(MaxHealth =>
            { 
                float offset = Mathf.Max(0, MaxHealth.Current - MaxHealth.Previous);
                CurrentHP.Value = Mathf.Min(CurrentHP.Value + offset, MaxHealth.Current);
            }).AddTo(this);

        }
        public void Initialize(float maxHP, float shield = 0f)
        {
            MaxHP.Value = maxHP;
            CurrentHP.Value = maxHP;
            Shield.Value = shield;
        }
    }

    public enum DamageType { Physical, Fire, Poison, Ice }
}