using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1回の冒険（ラン）の間だけ保持するデータ置き場。
/// static クラスなので、シーンを切り替えても中身が消えない。
/// 負けたら Clear() で全部リセットする（ローグライク方式）。
/// </summary>
public static class RunData
{
    // 冒険中かどうか
    public static bool IsActive { get; private set; }

    // 今のデッキ（1枚1要素）。報酬やデッキ編成で増減させる
    public static List<CardData> Deck { get; private set; } = new List<CardData>();

    // 次に戦う敵
    public static EnemyData NextEnemy { get; set; }

    /// <summary>
    /// 新しい冒険を始める（ホーム画面から呼ぶ）
    /// </summary>
    public static void StartNewRun(DeckData startingDeck, EnemyData firstEnemy)
    {
        Deck = startingDeck.ToCardList();
        NextEnemy = firstEnemy;
        IsActive = true;

        Debug.Log($"【冒険開始】デッキ {Deck.Count} 枚 / 最初の敵：{firstEnemy.EnemyName}");
    }

    /// <summary>
    /// 冒険のデータを全部消す（負けたとき・ホームに戻ったとき）
    /// </summary>
    public static void Clear()
    {
        Deck = new List<CardData>();
        NextEnemy = null;
        IsActive = false;
    }

    // このプロジェクトは「再生時にドメインをリロードしない」設定なので、
    // static変数が前回の再生の値を持ち越さないよう、再生開始のたびに初期化する
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetOnPlay()
    {
        Clear();
    }
}
