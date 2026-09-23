using UnityEngine;

public class TurnEndButton : MonoBehaviour
{
    BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = FindFirstObjectByType<BattleSystem>();
    }

    public void OnClickTurnEnd()
    {
        battleSystem.ChangeState(
            battleSystem.ResolveState
        );
    }
}
