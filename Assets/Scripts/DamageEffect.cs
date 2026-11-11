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

        // ▼ ここを変更：直接 target.Hp を引くのをやめ、TakeDamageに任せる
        target.TakeDamage(damageValue);
    }
}