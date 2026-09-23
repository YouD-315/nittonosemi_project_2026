using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    BattleSetupState setupState;
    BattlePlayerDrawState playerDrawState;
    BattleCardSelected cardSelectedState;
    BattleStateBase currentState;

    BattleResolveState resolveState;

    BattleInitialHandState initialHandState;



    public BattlePlayerDrawState PlayerDrawState { get { return playerDrawState; } }

    [SerializeField] Deck deck;

    [SerializeField] Boti boti;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;

    public Player Player
{
    get { return player; }
}

public Enemy Enemy
{
    get { return enemy; }
}

public Deck Deck
{
    get { return deck; }
}

public Boti Boti
{
    get { return boti; }
}

public BattleCardSelected CardSelectState

    {
        get { return cardSelectedState; }
    }       

public BattleResolveState ResolveState
{
    get { return resolveState; }
}

    public BattleInitialHandState InitialHandState
{
    get { return initialHandState; }
}

//選択中のカードを記憶
List<CardObj> selectedCards = new List<CardObj>();

public List<CardObj> SelectedCards
{
    get { return selectedCards; }
}

//Mana
int currentMana = 5;
int maxMana = 5;

public int CurrentMana
{
    get { return currentMana; }
    set { currentMana = value; }
}

public int MaxMana
{
    get { return maxMana; }
}

    void Start()
{
    Debug.Log("BattleSystemのStart");

    setupState = new BattleSetupState(this);
    initialHandState = new BattleInitialHandState(this);
    playerDrawState = new BattlePlayerDrawState(this);
    cardSelectedState = new BattleCardSelected(this);
    resolveState = new BattleResolveState(this);

    ChangeState(setupState);
}

void Update()
{
    currentState?.OnUpdate();
}

    //状態の切り替え
    public void ChangeState(BattleStateBase newState)
    {
        
        currentState = newState;
        currentState.OnEnter();
    }

}
