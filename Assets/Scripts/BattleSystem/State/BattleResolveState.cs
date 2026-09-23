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

    foreach (CardObj card in Owner.SelectedCards)
    {
        switch (card.CardType)
        {
            case CardType.Attack:
                Owner.Enemy.Hp -= 3;

            Debug.Log(
             "敵HP : " + Owner.Enemy.Hp
            );
             break;
    

            case CardType.Heal:
                Owner.Player.Hp += 3;

            Debug.Log(
             "自分HP : " + Owner.Player.Hp
            );
            break;

            case CardType.Guard:
                Debug.Log("防御発動");
                break;
        }

        card.SendToBoti(
            Owner.Boti.transform
        );
    }

    Owner.SelectedCards.Clear();

    Owner.CurrentMana = Owner.MaxMana;

    Owner.ChangeState(
        Owner.PlayerDrawState
    );
}



}

