using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardObj : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Text cardName;
    [SerializeField] Text cardDescription;
    [SerializeField] Image cardImage;
    [SerializeField] Text cardCost;
    [SerializeField] GameObject selectFrame;
    


public int Cost
{
    get { return cardData.cost; }
}

public CardType CardType
{
    get { return cardData.cardType; }
}

public CardData Data
{
    get { return cardData; }
}

    BattleSystem battleSystem;

    bool isSelected = false;

   CardData cardData;

public void Setup(CardData data)
{
    cardData = data;

    cardName.text = data.cardName;
    cardDescription.text = data.description;
    cardCost.text = data.cost.ToString();
    cardImage.sprite = data.cardImage;
}

    private void Start()
    {
        battleSystem = FindAnyObjectByType<BattleSystem>();

        selectFrame.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
{
    if (!isSelected)
    {
        if (battleSystem.CurrentMana < Cost)
        {
            Debug.Log("マナ不足");
            return;
        }

        battleSystem.CurrentMana -= Cost;

        battleSystem.SelectedCards.Add(this);

        selectFrame.SetActive(true);

        isSelected = true;
    }
    else
    {
        battleSystem.CurrentMana += Cost;

        battleSystem.SelectedCards.Remove(this);

        selectFrame.SetActive(false);

        isSelected = false;
    }

    Debug.Log("現在マナ : " + battleSystem.CurrentMana);
}

public void SendToBoti(Transform boti)
{
    Deselect();

    transform.SetParent(boti, false);

    gameObject.SetActive(false);
}

public void Deselect()
{
    isSelected = false;

    selectFrame.SetActive(false);
}



}