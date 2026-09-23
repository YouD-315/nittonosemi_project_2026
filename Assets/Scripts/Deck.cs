using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] CardObj cardObjPrefab;
    [SerializeField] Hand hand;

    List<CardObj> cards = new List<CardObj>();

    void Start()
    {
        for(int i = 0; i < 20; i++)
{
    CardObj cardObj = Spawn();

    CardType randomType =
        (CardType)Random.Range(0, 3);

    cardObj.Setup(randomType);

    cardObj.gameObject.SetActive(false);

    cards.Add(cardObj);
}

    }

    public void DrawToHand()
    {
        if (cards.Count == 0) return;

        CardObj drawCard = Draw();

        drawCard.transform.SetParent(hand.transform, false);
        drawCard.gameObject.SetActive(true);
    }

    private CardObj Draw()
    {
        CardObj cardObj = cards[0];
        cards.RemoveAt(0);
        return cardObj;
    }

    private CardObj Spawn()
    {
        return Instantiate(cardObjPrefab, transform);
    }

    public int CardCount
{
    get { return cards.Count; }
}
}
