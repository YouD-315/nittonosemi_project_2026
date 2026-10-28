using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public abstract void Execute(Character user, Character target, BattleSystem battleSystem);
}