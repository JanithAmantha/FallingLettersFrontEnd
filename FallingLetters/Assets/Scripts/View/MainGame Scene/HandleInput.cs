using UnityEngine;
using TMPro;

/// <summary>
/// 
///  This class checks if the correct letter is pressed
///  for the relevant falling letter. This class is attached to 
///  all falling letter objects in MainGame.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleInput:MonoBehaviour
{
    private string _generatedLetter;
    [SerializeField] private TMP_Text _tmpText;

    /// <summary>
    /// 
    ///  Obtains the letter in the falling letter object when its
    ///  created.
    /// 
    /// </summary>
    private void Start() {
        _generatedLetter = _tmpText.text;
    }

    /// <summary>
    /// 
    ///  Checks if the correct letter is pressed on keyboard.
    ///  If yes, the object gets destroyed and score is increased.
    /// 
    /// </summary>
    private void Update() {
        if(Input.anyKeyDown){

            string pressedKey = Input.inputString;
            if(pressedKey.ToUpper() == _generatedLetter)
            {
                HandleGameLogic.Instance.SetScore();    
                Destroy(this.gameObject);                
            }
        }    
    }
}