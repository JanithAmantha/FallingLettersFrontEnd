using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// 
///  This class is used to display player details in the LeaderBoard Scene.
/// 
///  This class contains AI generated content.
/// 
/// </summary>
public class HandleScrolls : MonoBehaviour
{
    [SerializeField] private GameObject _playerItemPrefab; 
    [SerializeField] private Transform _contentPanel;      
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _score;

    /// <summary>
    /// 
    ///  Start function initiates the InitiatePopulation function
    /// 
    /// </summary>
    private void Start()
    {
        InitiatePopulation();
    }

    /// <summary>
    ///
    ///  This function is responsible for obtaining data returned by model functions
    ///  and for passing the obtained data to the Populate function to display them.
    ///  
    /// </summary>
    private async void InitiatePopulation()
    {
        try{
            List<DataGetUsers> players = await new FireBaseController().GetPlayerData(PlayerController.Player.Token);
            players = players.OrderByDescending(player => player.score).ToList();

            if(players == null)
            {
                SceneManager.LoadScene("InternetChecker");
            }

            Populate(players);

        }
        catch(Exception e){
            Debug.Log("Error : " + e);
            SceneManager.LoadScene("InternetChecker");

        }

    }

    /// <summary>
    /// 
    ///  This function is responsible for displaying all player data in a scroll view in GUI.
    ///  
    ///  This function is generated by the LLM ChatGPT (GPT-4) by OpenAI.
    /// 
    /// </summary>
    /// 
    /// <param name="players"> List of GetUser type containing all the players. </param>
    private void Populate(List<DataGetUsers> players)
    {
        int i = 1;
        foreach (var player in players)
        {
            GameObject newItem = Instantiate(_playerItemPrefab, _contentPanel);
            
            if(player.isCurrentUser)
            {
                newItem.GetComponent<Image>().color = new Color(0, 0.5f, 0);
                _rank.SetText("Your Rank:" +i);
                _score.SetText("Your Highscore:"+player.score);
            }
 
            TextMeshProUGUI[] texts = newItem.GetComponentsInChildren<TextMeshProUGUI>();
            if(player.username.Length>6)
            {
                player.username = player.username.Substring(0,6)+"...";
            }
            
            texts[0].text = i.ToString();
            texts[1].text = player.username; 
            texts[2].text = player.score.ToString();
            i++;
        }

    }
}