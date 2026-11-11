using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Game/Card")]
public class CardData : ScriptableObject
{
    public string cardName;

    [TextArea]
    public string description;

    public int cost;

    // ▼ ここから追加
    [SerializeField] int speed = 0;

    public int Speed
    {
        get { return speed; }
    }
    // ▲ ここまで追加

    public Sprite cardImage;

    public CardType cardType;

    [SerializeField] List<CardEffect> effects = new List<CardEffect>();

    public List<CardEffect> Effects
    {
        get { return effects; }
    }
}