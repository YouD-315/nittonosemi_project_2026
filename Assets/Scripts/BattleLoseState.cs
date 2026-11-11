using UnityEngine;

public class BattleLoseState : BattleStateBase
{
    public BattleLoseState(BattleSystem owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("===== 敗北...ゲームオーバー =====");
        // 将来的にゲームオーバーUIの表示などをここに追加できます
    }
}