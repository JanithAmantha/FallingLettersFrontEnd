using TMPro;
using UnityEngine;

/// <summary>
/// 
///   Responsible for displaying changing details during the game.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleDisplayDetails : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _attempts;
    [SerializeField] private TMP_Text _levelText;

    /// <summary>
    /// 
    ///  Responsibility of this Update function is to display texts to users the moment they change.
    ///  (attempts, level, score)
    /// 
    /// </summary>
    private void Update() 
    {
        _attempts.SetText(HandleGameLogic.Instance.AttemptCount.ToString());
        _scoreText.SetText("Score : "+HandleGameLogic.Instance.Score.ToString());
        _levelText.SetText(HandleGameLogic.Instance.Level.ToString());
    }
}