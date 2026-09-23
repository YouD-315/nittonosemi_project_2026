using UnityEngine;

public class BattleInitialHandState : BattleStateBase
{
    public BattleInitialHandState(BattleSystem owner)
        : base(owner)
    {
    }

    public override void OnEnter()
    {
        for (int i = 0; i < 5; i++)
        {
            Owner.Deck.DrawToHand();
        }

        Owner.ChangeState(
            Owner.CardSelectState
        );
    }
}
