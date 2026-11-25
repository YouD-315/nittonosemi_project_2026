using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] CardObj cardObjPrefab;
    [SerializeField] Hand hand;
    [SerializeField] Boti boti; // ▼ 追加：墓地の参照
    [SerializeField] DeckData startingDeck; // ▼ 変更：ランダム20枚ではなく、このデッキ構成を使う

    List<CardObj> cards = new List<CardObj>();

    // Start ではなく Awake：BattleSystem.Start() で手札を配るより前に、必ず山札を作り終えておくため
    void Awake()
    {
        // 冒険中なら、RunDataにある「今のデッキ」を使う
        if (RunData.IsActive)
        {
            SetupDeck(RunData.Deck);
            return;
        }

        // ホームを通らずに戦闘シーンを直接再生したとき用（テスト用の初期デッキ）
        if (startingDeck == null)
        {
            Debug.LogWarning("Deck に Starting Deck が設定されていません");
            return;
        }

        SetupDeck(startingDeck.ToCardList());
    }

    /// <summary>
    /// 渡されたカードリスト（1枚1要素）から山札を作り、シャッフルする。
    /// 今後、デッキ編成画面で組んだデッキもここに渡す予定。
    /// </summary>
    public void SetupDeck(List<CardData> deckList)
    {
        foreach (CardData data in deckList)
        {
            CardObj cardObj = Spawn();
            cardObj.Setup(data);
            cardObj.gameObject.SetActive(false);
            cards.Add(cardObj);
        }

        Shuffle();
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

        Shuffle();
    }

    /// <summary>
    /// Fisher-Yatesアルゴリズムによる山札のランダムシャッフル
    /// </summary>
    private void Shuffle()
    {
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