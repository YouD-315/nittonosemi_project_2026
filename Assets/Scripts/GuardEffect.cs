using UnityEngine;

[CreateAssetMenu(fileName = "NewGuardEffect", menuName = "Card Game/Effect/Guard")]
public class GuardEffect : CardEffect
{
    [SerializeField] int guardValue = 3;

    public override void Execute(Character user, Character target, BattleSystem battleSystem)
    {
        if (user == null)
        {
            Debug.LogWarning("使用者（User）が存在しません");
            return;
        }

        user.Guard += guardValue;
        Debug.Log($"{user.name} がシールドを {guardValue} 獲得！（現在Guard: {user.Guard}）");
    }
}