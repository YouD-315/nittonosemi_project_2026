using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageEffect", menuName = "Card Game/Effect/Damage")]
public class DamageEffect : CardEffect
{
    [SerializeField] int damageValue = 3;

    public override void Execute(Character user, Character target, BattleSystem battleSystem)
    {
        if (target == null)
        {
            Debug.LogWarning("対象（Target）が存在しません");
            return;
        }

        target.Hp -= damageValue;
        Debug.Log($"{user.name} が {target.name} に {damageValue} ダメージを与えた！（残りHP: {target.Hp}）");
    }
}