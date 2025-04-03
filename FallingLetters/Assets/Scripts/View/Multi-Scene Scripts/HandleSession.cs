using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  This class checks for availability in player object in every frame.
///  If the player object is null the user is considered to logged out or the token
///  is expired. Hence, this directs the player to login page the moment player object is nulled.
///  The class is used by all the scenes available in the game.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleSession : MonoBehaviour
{
    /// <summary>
    ///
    ///  Checks if the player object is null every frame.
    /// 
    /// </summary>
    private void Update()
    {
        if(PlayerController.Player==null)
        {
            SceneManager.LoadScene("Login");
        }
    }
}