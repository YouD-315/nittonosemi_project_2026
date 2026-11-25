using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    // 敵の設定はすべてここ（EnemyData）で行う
    [SerializeField] EnemyData enemyData;

    // ▼ 変更：[SerializeField] を外した。Inspectorには出さず、EnemyDataから受け取った値を入れておくだけの変数
    int maxMana;
    List<CardData> usableCards = new List<CardData>();

    public int MaxMana
    {
        get { return maxMana; }
    }

    protected override void Awake()
    {
        // 冒険中なら、RunDataで指定された「次の敵」を使う
        if (RunData.IsActive && RunData.NextEnemy != null)
        {
            enemyData = RunData.NextEnemy;
        }

        if (enemyData == null)
        {
            Debug.LogWarning($"{name} に Enemy Data が設定されていません");
            base.Awake();
            return;
        }

        ApplyData(enemyData);
    }

    /// <summary>
    /// 敵データの内容を、このEnemyに反映する
    /// （今後、クエスト選択画面から別の敵データを渡すときにも使う）
    /// </summary>
    public void ApplyData(EnemyData data)
    {
        enemyData = data;

        name = data.EnemyName;
        SetMaxHp(data.MaxHp);
        maxMana = data.MaxMana;
        usableCards = new List<CardData>(data.UsableCards);

        // 同じオブジェクトに付いているImageの絵を差し替える
        Image image = GetComponent<Image>();
        if (image != null && data.Sprite != null)
        {
            image.sprite = data.Sprite;
        }
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