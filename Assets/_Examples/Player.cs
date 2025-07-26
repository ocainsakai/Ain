using Ain.ActionSystem;
using Ain.ActionSystem.Actions;
using Ain.HealthSystem;
using UniRx;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Health HealthSystem { get; private set; }
    public HealthComponent HealthComponent;
    public ActionController ActionController;
    [SerializeField] Enemy enemy;
    private void Awake()
    {
        HealthSystem = new Health(HealthComponent);
        HealthComponent.Initialize(100f, 50f); 
        ActionController = GetComponent<ActionController>();
        //ActionController.ActionStates.Add(new AttackAction(ActionController, enemy.HealthSystem, 50));
    }

    [ContextMenu("Atk")]
    public void Attack()
    {
        ActionController.ChangeState(new AttackAction(ActionController, enemy.HealthSystem, 50));
    }
}
