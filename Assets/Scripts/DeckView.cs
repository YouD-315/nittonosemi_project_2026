using UnityEngine;
using UnityEngine.UI;

public class DeckView : MonoBehaviour
{
    [SerializeField] Text deckText;

    BattleSystem battleSystem;

    void Start()
    {
        battleSystem = FindFirstObjectByType<BattleSystem>();
    }

    void Update()
    {
        deckText.text =
            battleSystem.Deck.CardCount.ToString();
    }
}