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
    [SerializeField] int cost;
    [SerializeField] CardType cardType;
    

[SerializeField] Sprite attackSprite;
[SerializeField] Sprite healSprite;
[SerializeField] Sprite guardSprite;


public CardType CardType
{
    get { return cardType; }
}

    public int Cost
    {
    get { return cost; }
    }

    BattleSystem battleSystem;

    bool isSelected = false;

   public void Setup(CardType type)
{
    cardType = type;

    switch (type)
    {
        case CardType.Attack:
            cardName.text = "攻撃";
            cardDescription.text = "敵に3ダメージ";
            cost = 1;
            cardImage.sprite = attackSprite;
            break;

        case CardType.Heal:
            cardName.text = "回復";
            cardDescription.text = "HPを3回復";
            cost = 2;
            cardImage.sprite = healSprite;
            break;

        case CardType.Guard:
            cardName.text = "防御";
            cardDescription.text = "防御力+3";
            cost = 1;
            cardImage.sprite = guardSprite;
            break;
    }

    cardCost.text = cost.ToString();
}

    private void Start()
    {
        battleSystem = FindFirstObjectByType<BattleSystem>();

        selectFrame.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
{
    if (!isSelected)
    {
        if (battleSystem.CurrentMana < cost)
        {
            Debug.Log("マナ不足");
            return;
        }

        battleSystem.CurrentMana -= cost;

        battleSystem.SelectedCards.Add(this);

        selectFrame.SetActive(true);

        isSelected = true;
    }
    else
    {
        battleSystem.CurrentMana += cost;

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