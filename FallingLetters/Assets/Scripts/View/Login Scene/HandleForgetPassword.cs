using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  This class manages the forget password functionality. 
///  Responsible for sending user email to model classes to send password reset requests.
///  Implements HandleButtonClick and HandleResponse. 
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleForgetPassword : MonoBehaviour, HandleResponse, HandleButtonClick
{
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private GameObject[] _nextPanels;


    public void NextAction(string response)
    {
        if(response == "success")
        {
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[0]);
        }
        else
        {
            HandlePanelTransition.Instance.SpawnPanel(_nextPanels[1]);
        }
    }

    public void OnClick()
    {
        ForgetPassword();
    }


    /// <summary>
    ///
    ///  The method initiates password reset by sending password 
    ///  reset request to model classes.
    /// 
    /// </summary>
    private async void ForgetPassword()
    {
        try{

            string response = await new FireBaseController().ConnectForgetPassword(_email.text);
            NextAction(response);

        }catch(Exception e){

            Debug.Log("Error : " + e);
            SceneManager.LoadScene("InternetChecker");
        }
    }
}