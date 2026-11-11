using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] int maxMana = 3;
    [SerializeField] List<CardData> usableCards = new List<CardData>();

    public int MaxMana
    {
        get { return maxMana; }
    }

    /// <summary>
    /// マナの許す限りカードを選択して返す
    /// </summary>
    public List<CardData> ChooseCards()
    {
        List<CardData> chosenCards = new List<CardData>();
        int currentMana = maxMana;

        // 使用可能なカード候補を順番に見て、マナが足りるなら選ぶ
        foreach (CardData card in usableCards)
        {
            if (card != null && card.cost <= currentMana)
            {
                chosenCards.Add(card);
                currentMana -= card.cost;
                Debug.Log($"敵がカードを選択: {card.cardName} (消費マナ: {card.cost}, 残りマナ: {currentMana})");
            }
        }

        return chosenCards;
    }
}