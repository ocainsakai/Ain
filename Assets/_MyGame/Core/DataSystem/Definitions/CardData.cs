using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public string ID;
    public string DisplayName;
    public Sprite Icon;
    public int ManaCost;
    public string Description;
}
