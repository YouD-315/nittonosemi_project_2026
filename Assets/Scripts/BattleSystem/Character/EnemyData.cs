using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵1種類分の設定（名前・見た目・HP・マナ・使うカード）を保存するデータ。
/// クエストごとにこのアセットを差し替えて、出てくる敵を変える。
/// </summary>
[CreateAssetMenu(fileName = "NewEnemy", menuName = "Card Game/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] string enemyName = "ゴブリン";
    [SerializeField] Sprite sprite;
    [SerializeField] int maxHp = 20;
    [SerializeField] int maxMana = 3;
    [SerializeField] List<CardData> usableCards = new List<CardData>();

    public string EnemyName { get { return enemyName; } }
    public Sprite Sprite { get { return sprite; } }
    public int MaxHp { get { return maxHp; } }
    public int MaxMana { get { return maxMana; } }
    public List<CardData> UsableCards { get { return usableCards; } }
}
