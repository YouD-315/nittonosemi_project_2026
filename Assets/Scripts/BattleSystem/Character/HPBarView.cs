using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// キャラクターのHPをバー（と数字）で表示する。プレイヤー・敵どちらにも使える。
/// </summary>
public class HPBarView : MonoBehaviour
{
    [SerializeField] Character targetCharacter;
    [SerializeField] Image fillImage;   // Image Type = Filled にした緑のバー
    [SerializeField] Text hpText;       // 「15/20」のような数字（不要なら空欄でOK）

    private void Update()
    {
        if (targetCharacter == null || targetCharacter.MaxHp <= 0)
        {
            return;
        }

        // 現在HP ÷ 最大HP で 0.0〜1.0 の割合を出し、バーの長さにする
        fillImage.fillAmount = (float)targetCharacter.Hp / targetCharacter.MaxHp;

        if (hpText != null)
        {
            hpText.text = $"{targetCharacter.Hp}/{targetCharacter.MaxHp}";
        }
    }
}
