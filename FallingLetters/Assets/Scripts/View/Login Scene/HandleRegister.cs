using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  This class is responsible for Register functionality of the game.
///  Responsible for passing front end data to model classes. 
///  Implements HandleResponse and HandleButtonClick interfaces.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleRegister:MonoBehaviour, HandleResponse, HandleButtonClick
{
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _username;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_InputField _confirmPassword;
    [SerializeField] private GameObject[] _nextPanels;

    public void NextAction(string response)
    {
        if(response=="success")
        {
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[3]);
        }
        else if(response=="The user with the provided email already exists (EMAIL_EXISTS).")
        {
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[0]);
        }
        else if(response == "Malformed email address string"){
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[1]);
        }
        else{
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[2]);
        }

    }

    public void OnClick()
    {
        Register();
    }


    /// <summary>
    /// 
    ///  It will initiate the register request and pass the data user enters to the GUI 
    ///  to the model classes.
    /// 
    /// </summary>
    public async void Register()
    {
        try{

            string playerEmail = _email.text;
            string playerName = _username.text;
            string playerPassword = _password.text;
            string playerConfirmPassword = _confirmPassword.text;
            FireBaseController databaseHandler = new FireBaseController();
            string response = await databaseHandler.RegisterUser(playerEmail,playerPassword,playerName);
            Debug.Log("Response:"+response);
            NextAction(response);
        }
        catch(Exception e)
        {
            Debug.Log("Error : " + e);
            SceneManager.LoadScene("InternetChecker");
        }
    }

}