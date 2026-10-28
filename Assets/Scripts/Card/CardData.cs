using System.Collections.Generic; // Listを使うために追加
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Game/Card")]
public class CardData : ScriptableObject
{
    public string cardName;

    [TextArea]
    public string description;

    public int cost;

    public Sprite cardImage;

    public CardType cardType;

    // ▼ ここから追加
    [SerializeField] List<CardEffect> effects = new List<CardEffect>();

    public List<CardEffect> Effects
    {
        get { return effects; }
    }
    // ▲ ここまで追加
}