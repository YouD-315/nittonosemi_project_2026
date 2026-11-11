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

        // 速度（Speed）降順で並べ替え
        actionList.Sort((a, b) => b.CardData.Speed.CompareTo(a.CardData.Speed));

        // 3. 行動リストを順番に実行
        foreach (CardAction action in actionList)
        {
            foreach (CardEffect effect in action.CardData.Effects)
            {
                effect.Execute(action.User, action.Target, Owner);
            }

            if (action.CardObj != null)
            {
                action.CardObj.SendToBoti(Owner.Boti.transform);
            }

            // ▼ ここを追加：1行動ごとに勝敗判定を行う
            if (Owner.Enemy.Hp <= 0)
            {
                Debug.Log("敵のHPが0になりました。");
                Owner.SelectedCards.Clear();
                Owner.ChangeState(Owner.WinState);
                return; // 残りのカード処理を中断して抜ける
            }

            if (Owner.Player.Hp <= 0)
            {
                Debug.Log("プレイヤーのHPが0になりました。");
                Owner.SelectedCards.Clear();
                Owner.ChangeState(Owner.LoseState);
                return; // 残りのカード処理を中断して抜ける
            }
        }

        // 4. 決着がつかなかった場合のみ次のターンへ進む
        Owner.SelectedCards.Clear();
        Owner.CurrentMana = Owner.MaxMana;
        Owner.ChangeState(Owner.PlayerDrawState);
    }
}