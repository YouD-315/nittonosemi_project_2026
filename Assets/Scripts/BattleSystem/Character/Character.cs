using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int hp = 20;
    int guard = 0;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Guard
    {
        get { return guard; }
        set { guard = value; }
    }

    // ▼ ここから追加
    /// <summary>
    /// ガードを優先消費し、余ったダメージをHPから引く処理
    /// </summary>
    public void TakeDamage(int damage)
    {
        int remainingDamage = damage;

        // 1. ガードがある場合はガードでダメージを軽減
        if (guard > 0)
        {
            if (guard >= remainingDamage)
            {
                // ガードだけでダメージを全額防ぎきった場合
                guard -= remainingDamage;
                remainingDamage = 0;
            }
            else
            {
                // ガードが割れ、余りダメージが残る場合
                remainingDamage -= guard;
                guard = 0;
            }
        }

        // 2. ガードを貫通したダメージがあればHPを減らす
        if (remainingDamage > 0)
        {
            hp -= remainingDamage;
            if (hp < 0)
            {
                hp = 0; // HPがマイナスにならないよう安全対策
            }
        }

        Debug.Log($"{name} が {damage} ダメージを受けた！（消費後Guard: {guard}, 残りHP: {hp}）");
    }
    // ▲ ここまで追加
}