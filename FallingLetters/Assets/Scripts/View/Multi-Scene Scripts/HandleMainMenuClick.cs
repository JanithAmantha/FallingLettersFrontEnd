using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  Responses to the button click in multiple Scenes.
///  Load MainMenu Scene.
///  Implements HandleButtonClick.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleMainMenuClick : MonoBehaviour, HandleButtonClick
{
    public void OnClick()
    {
        SceneManager.LoadScene("MainMenu");

    }
}