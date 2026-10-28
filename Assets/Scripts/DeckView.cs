using UnityEngine;
using UnityEngine.UI;

public class DeckView : MonoBehaviour
{
    [SerializeField] Text deckText;

    BattleSystem battleSystem;

    void Start()
    {
        battleSystem = FindAnyObjectByType<BattleSystem>();
    }

    void Update()
    {
        deckText.text =
            battleSystem.Deck.CardCount.ToString();
    }
}