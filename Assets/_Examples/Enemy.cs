using Ain.HealthSystem;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health HealthSystem { get; private set; }
    public HealthComponent HealthComponent;
    [SerializeField] Player player;
    private void Awake()
    {
        HealthSystem = new Health(HealthComponent);
        HealthComponent.Initialize(100f, 0f); 
    }

    [ContextMenu("Attack Player")]
    public void Attack()
    {
        
            player?.HealthSystem?.TakeDamage(10, DamageType.Physical);
        
    }
}
