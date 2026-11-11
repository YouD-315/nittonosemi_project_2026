using UnityEngine;

public class BattleWinState : BattleStateBase
{
    public BattleWinState(BattleSystem owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("===== 勝利！戦闘終了 =====");
        // 将来的に勝利リザルトUIの表示などをここに追加できます
    }
}