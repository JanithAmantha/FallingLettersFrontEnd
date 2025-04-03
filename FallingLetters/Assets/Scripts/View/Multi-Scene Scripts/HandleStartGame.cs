using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  Responses to the button click in multiple Scenes.
///  Starts MainGame Scene.
///  Implements HandleButtonClick.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleStartGame : MonoBehaviour, HandleButtonClick
{
    public void OnClick()
    {
        SceneManager.LoadScene("MainGame");
        
    }
}