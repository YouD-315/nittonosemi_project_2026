using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デッキの構成（どのカードを何枚入れるか）を保存するデータ。
/// 初期デッキやキャラごとのデッキとして使う。
/// </summary>
[CreateAssetMenu(fileName = "NewDeck", menuName = "Card Game/Deck")]
public class DeckData : ScriptableObject
{
    // 「カード」と「枚数」の組み合わせ1行分
    [System.Serializable]
    public class Entry
    {
        public CardData card;
        public int count = 1;
    }

    [SerializeField] List<Entry> entries = new List<Entry>();

    /// <summary>
    /// 枚数分だけカードを並べた、1枚1要素のリストに変換して返す
    /// （例：ドロー×2, 防御×1 → [ドロー, ドロー, 防御]）
    /// </summary>
    public List<CardData> ToCardList()
    {
        List<CardData> result = new List<CardData>();

        foreach (Entry entry in entries)
        {
            if (entry.card == null)
            {
                continue;
            }

            for (int i = 0; i < entry.count; i++)
            {
                result.Add(entry.card);
            }
        }

        return result;
    }
}
