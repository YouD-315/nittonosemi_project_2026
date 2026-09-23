using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateBase
// Start is called once before the first execution of Update after the MonoBehaviour is created
{
    protected BattleSystem Owner;
    public BattleStateBase(BattleSystem owner)
    {
        Owner = owner;
    }
    //その状態に入った時呼ばれる
    public virtual void OnEnter()
    {}
    public virtual void OnUpdate()
    {}
    public virtual void OnExit()
    {}
}
