using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
///  Used to perform input validation during password reset request initiation.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleForgetPasswordValidate : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailInputField;
    [SerializeField] private TMP_Text _warningTextEmail;
    [SerializeField] private Button _sendButton;

    /// <summary>
    /// 
    ///  Disables the send button upon start.
    ///  Attaches onValueChanged event to the input field to continuously validate the input.
    /// 
    /// </summary>
    private void Start()
    {
        _sendButton.interactable = false;
        _emailInputField.onValueChanged.AddListener(ValidateForm);
    }

    /// <summary>
    /// 
    ///  Performs input validation by accessing functions of the InputValidator.
    /// 
    /// </summary>
    /// 
    /// <param name="_"> Ignored parameter. User because onValueChanged listener demands it. </param>
    private void ValidateForm(string _)
    {
        string email = _emailInputField.text;

        if (InputValidator.IsFieldEmpty(email, _warningTextEmail, "Email")) return;
        if (!InputValidator.IsValidEmail(email, _warningTextEmail)) return;
        _sendButton.interactable = true;
    }
    
}