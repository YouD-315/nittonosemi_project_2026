using System.Collections.Generic;
using UnityEngine;

public class Boti : MonoBehaviour
{
    /// <summary>
    /// 墓地にあるカードの枚数を返す
    /// </summary>
    public int CardCount
    {
        get { return transform.childCount; }
    }

    /// <summary>
    /// 墓地にある全てのCardObjを回収してリストで返す
    /// </summary>
    public List<CardObj> CollectAllCards()
    {
        List<CardObj> collectedCards = new List<CardObj>();

        // 墓地（Boti）の子オブジェクトにあるCardObj（非アクティブ含む）を全取得
        CardObj[] botiCards = GetComponentsInChildren<CardObj>(true);

        foreach (CardObj card in botiCards)
        {
            collectedCards.Add(card);
        }

        return collectedCards;
    }
}