using System.Collections; // ▼ コルーチン（IEnumerator）を使うために追加
using System.Collections.Generic;
using UnityEngine;

public class BattleResolveState : BattleStateBase
{
    public BattleResolveState(BattleSystem owner)
        : base(owner)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("===== Resolve開始 =====");

        List<CardAction> actionList = new List<CardAction>();

        // 1. プレイヤーの行動を追加
        foreach (CardObj card in Owner.SelectedCards)
        {
            CardAction playerAction = new CardAction(Owner.Player, Owner.Enemy, card.Data, card);
            actionList.Add(playerAction);
        }

        // 2. 敵の行動を追加
        List<CardData> enemyCards = Owner.Enemy.ChooseCards();
        foreach (CardData cardData in enemyCards)
        {
            CardAction enemyAction = new CardAction(Owner.Enemy, Owner.Player, cardData);
            actionList.Add(enemyAction);
        }

        // 3. 速度順に降順ソート
        actionList.Sort((a, b) => b.CardData.Speed.CompareTo(a.CardData.Speed));

        // 4. MonoBehaviourであるBattleSystem(Owner)にコルーチンを実行させる
        Owner.StartCoroutine(ResolveRoutine(actionList));
    }

    /// <summary>
    /// カードを1枚ずつ順番に発動し、合間にウェイトを挟む演出コルーチン
    /// </summary>
    private IEnumerator ResolveRoutine(List<CardAction> actionList)
    {
        foreach (CardAction action in actionList)
        {
            // 誰のカードが発動したかログ出力
            Debug.Log($"【発動】{action.User.name} の {action.CardData.cardName}！");

            // カード効果の実行
            foreach (CardEffect effect in action.CardData.Effects)
            {
                effect.Execute(action.User, action.Target, Owner);
            }

            // プレイヤーのカードなら墓地へ送る
            if (action.CardObj != null)
            {
                action.CardObj.SendToBoti(Owner.Boti.transform);
            }

            // ▼ ここが演出ウェイト：1秒間待機する
            yield return new WaitForSeconds(1.0f);

            // 勝敗判定チェック
            if (Owner.Enemy.Hp <= 0)
            {
                CleanupAndFinish();
                Owner.ChangeState(Owner.WinState);
                yield break; // コルーチンをここで即座に終了
            }

            if (Owner.Player.Hp <= 0)
            {
                CleanupAndFinish();
                Owner.ChangeState(Owner.LoseState);
                yield break; // コルーチンをここで即座に終了
            }
        }

        // 全カードの処理が終わり、決着がつかなければ次ターンへ
        CleanupAndFinish();
        Owner.ChangeState(Owner.PlayerDrawState);
    }

    private void CleanupAndFinish()
    {
        Owner.SelectedCards.Clear();
        Owner.CurrentMana = Owner.MaxMana;
    }
}