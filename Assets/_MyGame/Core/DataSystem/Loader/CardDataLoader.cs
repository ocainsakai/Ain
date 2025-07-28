using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDataLoader : MonoBehaviour
{
    [SerializeField] private List<CardData> cardDataList;

    private Dictionary<string, CardData> _cardLookup;

    private void Awake()
    {
        _cardLookup = cardDataList.ToDictionary(card => card.ID);
    }

    public CardData GetCardByID(string id)
    {
        return _cardLookup.TryGetValue(id, out var card) ? card : null;
    }
}
