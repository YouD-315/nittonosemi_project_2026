using UnityEngine;
using UnityEngine.UI;

public class BotiView : MonoBehaviour
{
    [SerializeField] Text botiText;

    BattleSystem battleSystem;

    void Start()
    {
        battleSystem = FindFirstObjectByType<BattleSystem>();
    }

    void Update()
    {
        botiText.text =
            battleSystem.Boti.CardCount.ToString();
    }
}