using UnityEngine;
using UnityEngine.UI;

public class EnemyHPView : MonoBehaviour
{
    [SerializeField] Text EnemyHP;
    [SerializeField] Character targetCharacter;

    private void Update()
    {
        EnemyHP.text = targetCharacter.Hp.ToString();
    }
}
