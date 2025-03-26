using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  Responses to the button click in MainMenu Scene.
///  Logs out of the game and loads Login Scene.
///  Implements HandleButtonClick.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleLogOutClicked : MonoBehaviour, HandleButtonClick
{
    public void OnClick()
    {
        PlayerController.LogOut();
        SceneManager.LoadScene("Login");
    }
}