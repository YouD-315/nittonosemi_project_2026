using UnityEngine;

public class TurnEndButton : MonoBehaviour
{
    BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = FindAnyObjectByType<BattleSystem>();
    }

    public void OnClickTurnEnd()
    {
        battleSystem.ChangeState(
            battleSystem.ResolveState
        );
    }
}
