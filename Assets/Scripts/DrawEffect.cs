using UnityEngine;

[CreateAssetMenu(fileName = "NewDrawEffect", menuName = "Card Game/Effect/Draw")]
public class DrawEffect : CardEffect
{
    [SerializeField] int drawCount = 1;

    public override void Execute(Character user, Character target, BattleSystem battleSystem)
    {
        // 山札（Deck）を持っているのはプレイヤーだけなので、敵が使った場合は何もしない
        if (!(user is Player))
        {
            Debug.Log($"{user.name} は山札を持たないため、ドロー効果は発動しません");
            return;
        }

        for (int i = 0; i < drawCount; i++)
        {
            battleSystem.Deck.DrawToHand();
        }

        Debug.Log($"{user.name} はカードを {drawCount} 枚引いた！");
    }
}
