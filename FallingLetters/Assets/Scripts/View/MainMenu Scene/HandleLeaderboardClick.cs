using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  Responses to the button click in MainMenu Scene.
/// Loads the LeaderBoard Scene.
///  Implements HandleButtonClick.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleLeaderboardClick : MonoBehaviour, HandleButtonClick
{
    public void OnClick()
    {
        SceneManager.LoadScene("LeaderBoard");
    }
}