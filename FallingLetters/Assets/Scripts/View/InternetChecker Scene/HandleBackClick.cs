using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  Responses to the button click in InternetCHecker Scene.
///  Handle GoBack function in InternetChecker.
///  Implements HandleButtonClick.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleBackClick : MonoBehaviour, HandleButtonClick
{
    public void OnClick()
    {
        if(PlayerController.player == null)
        {
            SceneManager.LoadScene("Login");
        }
        else{
            SceneManager.LoadScene("MainMenu");
        }
    }
    
}