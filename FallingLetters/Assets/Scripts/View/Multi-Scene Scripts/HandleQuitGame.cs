using UnityEngine;

/// <summary>
/// 
///  Responses to the button click in multiple Scenes.
///  Quits the game.
///  Implements HandleButtonClick.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleQuitGame : MonoBehaviour, HandleButtonClick
{
    public void OnClick()
    {
        Application.Quit();
        Debug.Log("Game Closed"); 

    }
}