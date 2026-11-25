using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ホーム画面のボタン処理。冒険を始めて戦闘シーンへ移動する。
/// </summary>
public class HomeMenu : MonoBehaviour
{
    [SerializeField] DeckData startingDeck;              // 冒険開始時のデッキ
    [SerializeField] EnemyData firstEnemy;               // 最初に戦う敵
    [SerializeField] string battleSceneName = "twentyseven"; // 戦闘シーンの名前

    /// <summary>
    /// 「冒険開始」ボタンの OnClick から呼ぶ
    /// </summary>
    public void OnClickStart()
    {
        RunData.StartNewRun(startingDeck, firstEnemy);
        SceneManager.LoadScene(battleSceneName);
    }
}
