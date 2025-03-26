using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 
///  This class is responsible for Login functionality of the game.
///  Responsible for passing front end data to model classes. 
///  Implements HandleResponse and HandleButtonClick interfaces.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleLogin : MonoBehaviour , HandleResponse, HandleButtonClick {
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private GameObject[] _nextPanels;
    [SerializeField] private Button _loginButton;

    /// <summary>
    /// 
    ///  In this start function, the button onClick event is manually handled by code
    ///  unlike other instances, to demonstrate that it can be handled through code as well.
    /// 
    /// </summary>
    private void Start()
    {
        _loginButton.onClick.AddListener(OnClick);
    }

    public void NextAction(string response)
    {
        if(response=="success")
        {
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[2]);
        }
        else if(response=="Incorrect email or password")
        {
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[0]);
        }
        else{
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[1]);
        }

    }

    public void OnClick()
    {
        LoginPlayer();
    }

    /// <summary>
    /// 
    ///  This method will initiate the login request and pass the data user enters to the GUI 
    ///  to the model classes.
    /// 
    /// </summary>
    private async void LoginPlayer()
    {
        try{
            Debug.Log("Button pressed");
            string playerEmail = _email.text;
            string playerPassword = _password.text;
            string response = await new FireBaseController().LoginUser(playerEmail,playerPassword);
            NextAction(response);

        }
        catch (Exception e){
            Debug.Log("Error : " + e);
            SceneManager.LoadScene("InternetChecker");
        }

 
    }
    
}