using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// 
///  This class manages the GameOver Scene.
///  Also responsible for updating player scores if they achiever a new 
///  highest score.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleGameOver : MonoBehaviour
{
    private float _score;
    [SerializeField] private TMP_Text _highScore;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private AudioSource _winSource;
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioSource _loseSource;
    [SerializeField] private AudioClip _loseClip;

    /// <summary>
    /// 
    ///  Start function that is always executed once.
    ///  it calls the ShowScore() function to display user score.
    /// 
    /// </summary>
    private void Start()
    {
        ShowScore();
    }

    /// <summary>
    /// 
    ///  This asynchronous method is responsible for showing the last game details on the screen.
    ///  This method initiates the update of user score in database if the player obtains a higher score.
    ///  Different audio clips are played for high score and lower score scenarios.
    /// 
    /// </summary>
    private async void ShowScore()
    {
        _score = PlayerPrefs.GetFloat("LastScore", 0);
        PlayerPrefs.DeleteAll();
        if(PlayerController.player.Score<_score)
        {
            _winSource.PlayOneShot(_winClip);
            _highScore.SetText("New HighScore ! Congratulations !");
            _currentScore.SetText("HighScore : "+_score);
            PlayerController.player.Score = (int)_score;
            try{
                await new FireBaseController().UpdateScore((int)_score,PlayerController.player.Token);
                return;
            }
            catch (Exception e){
                Debug.Log("Error : " + e);
                SceneManager.LoadScene("InternetChecker");
            }
        }
        _loseSource.PlayOneShot(_loseClip);
        _highScore.SetText("Your High Score : "+ PlayerController.player.Score);
        _currentScore.SetText("Current Score : "+_score);

    }
}