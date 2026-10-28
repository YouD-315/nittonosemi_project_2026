using UnityEngine;

[CreateAssetMenu(fileName = "NewHealEffect", menuName = "Card Game/Effect/Heal")]
public class HealEffect : CardEffect
{
    [SerializeField] int healValue = 3;

    public override void Execute(Character user, Character target, BattleSystem battleSystem)
    {
        if (user == null)
        {
            Debug.LogWarning("使用者（User）が存在しません");
            return;
        }

        user.Hp += healValue;
        Debug.Log($"{user.name} のHPが {healValue} 回復！（現在HP: {user.Hp}）");
    }
}