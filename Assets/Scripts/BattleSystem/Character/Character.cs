using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int hp = 20;

    int guard = 0;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Guard
    {
        get { return guard; }
        set { guard = value; }
    }
}