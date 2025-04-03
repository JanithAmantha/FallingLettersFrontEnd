using UnityEngine;
using TMPro;

/// <summary>
/// 
///  Responsible for assigning letters to each falling letter object.
///  Used both in MainGame and MainMenu scenes.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleAssignLetters:MonoBehaviour
{
    [SerializeField] private TMP_Text _letterText;

    /// <summary>
    /// 
    ///  Assigns chosen letter to the falling letter object.
    /// 
    /// </summary>
    private void Start()
    {
        _letterText.SetText(GenerateRandomLetter().ToString());
        
    }

    /// <summary>
    /// 
    ///  Randomly chooses a letter between a - z in ASCII.
    /// 
    /// </summary>
    /// 
    /// <returns> Chosen letter as character type </returns>
    private static char GenerateRandomLetter(){
        int randomIndex = Random.Range(65, 91);
        return (char)randomIndex;  
    }
}