using UnityEngine;

public class BattleCardSelected : BattleStateBase
{
    public BattleCardSelected(BattleSystem owner)
        : base(owner)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("カード選択フェーズ");
    }

    public override void OnUpdate()
    {
        
    }
}