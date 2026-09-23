using UnityEngine;
using UnityEngine.UI;

public class PlayerHPView : MonoBehaviour
{
    [SerializeField] Text PlayerHP;
    [SerializeField] Character targetCharacter;

    private void Update()
    {
        PlayerHP.text = targetCharacter.Hp.ToString();
    }
}