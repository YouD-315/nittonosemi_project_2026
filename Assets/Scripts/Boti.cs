using UnityEngine;

public class Boti : MonoBehaviour
{
    public int CardCount
    {
        get
        {
            return GetComponentsInChildren<CardObj>(true).Length;
        }
    }
}