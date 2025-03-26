using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

/// <summary>
/// 
///  This class loads the image returned by the banana API to the GUI. Also it checks 
///  if the problem fetched is correctly answered.
///  Implements HandleButtonClick interface.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleAPICall : MonoBehaviour, HandleButtonClick
{
    [SerializeField] private Image _image;
    [SerializeField] private  TMP_Text _hint;
    [SerializeField] private TMP_InputField _answerField;
    private APIController _apiController;
    
    //Provides an additional hint to users.
    private string[] _hintsArray = { "1-1","0+1", "1+1", "10-7", "8/2", "25/5", "3+3", "4+3", "16/2", "5+4", "20-10" };

    /// <summary>
    /// 
    ///  This function is once executed whenever the attached component is loaded into the screen.
    ///  Fetches bananaAPI data whenever the component starts and loads the image into the holder
    /// 
    /// </summary>
    private async void Start()
    {
        try{
            _apiController = new APIController();
            await _apiController.apiConnection.FetchBananaDataAsync();
            LoadImage();

        }catch(Exception e)
        {
            Debug.Log("Error : " + e);
            SceneManager.LoadScene("InternetChecker");
        }

    }

    /// <summary>
    /// 
    ///  This function is called in every frame while the attached component is active.  
    ///  Duty of this is to check if the user enters the enter button to submit the solution.
    /// 
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Enter btn pressed");
            ValueEntered();
        }
    }

    public void OnClick()
    {
        ValueEntered();
    }

    /// <summary>
    /// 
    ///  Responsibility is to load the banana image to the GUI of the game.
    /// 
    /// </summary>
    private async void LoadImage()
    {
        if (!_apiController.apiConnection.urlUnlocked)
        {
            /*urlUnlocked is used to check if the image URL has been fetched by the model classes.
            If not the process of loading the image will cause errors. (It will try to load the image before the URL is fetched) */
            return;
        }

        try{
            await _apiController.apiConnection.LoadImageAsync(_apiController.apiConnection.bananaResponse.question);
            Texture2D texture2D = _apiController.apiConnection.returnedImage;
            if (texture2D != null)
            {
                _image.sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
                _hint.SetText("Hint:" + _hintsArray[_apiController.apiConnection.bananaResponse.solution]);
            }
        }
        catch (Exception e){
            Debug.Log("Error : " + e);
            SceneManager.LoadScene("InternetChecker");
        }

    }

    /// <summary>
    /// 
    ///  This function is used to validate if the user has given the correct solution to the
    ///  problem returned by the banana API.
    ///  Also, this function is attached to a click event of a button within the engine.
    /// 
    /// </summary>
    private void ValueEntered(){
        if(_answerField.text == _apiController.apiConnection.bananaResponse.solution.ToString())
        {
            SceneManager.LoadScene("MainGame");
        }
        else{
            HandleGameLogic.Instance.GameOver();
        }
    }
}
