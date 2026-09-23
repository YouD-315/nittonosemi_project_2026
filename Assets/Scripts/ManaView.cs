using UnityEngine;
using UnityEngine.UI;

public class ManaView : MonoBehaviour
{
    [SerializeField] Text manaText;

    BattleSystem battleSystem;

    private void Start()
    {
        battleSystem = FindFirstObjectByType<BattleSystem>();
    }

    private void Update()
    {
        manaText.text =
            battleSystem.CurrentMana +
            "/" +
            battleSystem.MaxMana;
    }
}