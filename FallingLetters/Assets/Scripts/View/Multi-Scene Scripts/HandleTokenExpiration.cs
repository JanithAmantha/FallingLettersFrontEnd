using UnityEngine;
using System;

/// <summary>
/// 
///  This class checks for the expiration of db token in every second.
///  If the token is expired it will log out the user from the game automatically.
///  The class is used by all the scenes available in the game.
/// 
///  This class contains AI generated content.
/// 
/// </summary>
public class HandleTokenExpiration : MonoBehaviour
{
    /// <summary>
    /// 
    ///  Starts the token timer in every scene.
    /// 
    /// </summary>
    void Update()
    {
        TokenTimer();
    }

    /// <summary>
    /// 
    ///  Checks if the token is expired by comparing it to the current UTC time.
    ///  Logs the player out if its expired.
    /// 
    ///  This function is generated by the LLM ChatGPT (GPT-4) by OpenAI.
    /// 
    /// </summary>
    private void TokenTimer()
    {
        if(PlayerController.player.ExpTime<= DateTimeOffset.UtcNow.ToUnixTimeSeconds())
        {
            PlayerController.LogOut();
        }
    }
}