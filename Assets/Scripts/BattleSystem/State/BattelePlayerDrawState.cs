using UnityEngine;

public class BattlePlayerDrawState : BattleStateBase
{
    public BattlePlayerDrawState(BattleSystem owner)
        : base(owner)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("1枚ドロー");

        Owner.Deck.DrawToHand();

        Owner.ChangeState(
            Owner.CardSelectState
        );
    }
}