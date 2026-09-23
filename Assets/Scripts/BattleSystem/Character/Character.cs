using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int hp = 20;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
}