using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] CardObj cardObjPrefab;
    [SerializeField] Hand hand;
    [SerializeField] Boti boti; // ▼ 追加：墓地の参照
    [SerializeField] List<CardData> cardDataList;

    List<CardObj> cards = new List<CardObj>();

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            CardObj cardObj = Spawn();

            CardData randomData =
                cardDataList[Random.Range(0, cardDataList.Count)];

            cardObj.Setup(randomData);

            cardObj.gameObject.SetActive(false);

            cards.Add(cardObj);
        }
    }

    public void DrawToHand()
    {
        // 山札が0枚なら、墓地からカードを回収してリシャッフル
        if (cards.Count == 0)
        {
            ReshuffleFromBoti();
        }

        // 墓地にもカードがなければ本当に引けないので中断
        if (cards.Count == 0)
        {
            Debug.Log("山札も墓地も空のためドローできません");
            return;
        }

        CardObj drawCard = Draw();

        drawCard.transform.SetParent(hand.transform, false);
        drawCard.gameObject.SetActive(true);
    }

    /// <summary>
    /// 墓地のカードを回収し、シャッフルして山札に補充する
    /// </summary>
    private void ReshuffleFromBoti()
    {
        if (boti == null)
        {
            Debug.LogWarning("Botiの参照が設定されていません");
            return;
        }

        List<CardObj> recycledCards = boti.CollectAllCards();

        if (recycledCards.Count == 0)
        {
            return;
        }

        Debug.Log($"【リシャッフル】墓地から {recycledCards.Count} 枚のカードを山札へ戻します");

        // 回収したカードの親をDeckオブジェクト配下に戻す
        foreach (CardObj card in recycledCards)
        {
            card.transform.SetParent(transform, false);
            cards.Add(card);
        }

        // Fisher-Yatesアルゴリズムによるリストのランダムシャッフル
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            CardObj temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
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