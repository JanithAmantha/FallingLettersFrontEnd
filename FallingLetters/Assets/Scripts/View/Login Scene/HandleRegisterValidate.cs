using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 
///  Used to perform input validation during register request initiation.
/// 
///  This class contains AI generated content.
/// 
/// </summary>
public class HandleRegisterValidate : MonoBehaviour
{
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_InputField _emailInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private TMP_InputField _confirmPasswordInputField;
    [SerializeField] private TMP_Text _warningTextUsername;
    [SerializeField] private TMP_Text _warningTextEmail;
    [SerializeField] private TMP_Text _warningTextPassword;
    [SerializeField] private TMP_Text _warningTextConfirmPassword;
    [SerializeField] private Button _registerButton;

    /// <summary>
    /// 
    ///  Disables the register button upon start.
    ///  Attaches onValueChanged event to the input fields to continuously validate the input.
    /// 
    ///  This function is generated by the LLM ChatGPT (GPT-4) by OpenAI.
    /// 
    /// </summary>
    private void Start()
    {
        _registerButton.interactable = false;
        _usernameInputField.onValueChanged.AddListener(ValidateForm);
        _emailInputField.onValueChanged.AddListener(ValidateForm);
        _passwordInputField.onValueChanged.AddListener(ValidateForm);
        _confirmPasswordInputField.onValueChanged.AddListener(ValidateForm);
    }

    /// <summary>
    /// 
    ///  Performs input validation by accessing functions of the InputValidator.
    /// 
    ///  This function is generated by the LLM ChatGPT (GPT-4) by OpenAI.
    /// 
    /// </summary>
    /// 
    /// <param name="_"> Ignored parameter. User because onValueChanged listener demands it. </param>
    private void ValidateForm(string _)
    {
        string username = _usernameInputField.text;
        string email = _emailInputField.text;
        string password = _passwordInputField.text;
        string confirmPassword = _confirmPasswordInputField.text;


        if (InputValidator.IsFieldEmpty(email, _warningTextEmail, "Email")) return;
        if (!InputValidator.IsValidEmail(email, _warningTextEmail)) return;
        if (InputValidator.IsFieldEmpty(username, _warningTextUsername, "Username")) return;
        if (InputValidator.IsFieldEmpty(password, _warningTextPassword, "Password")) return;
        if (!InputValidator.IsPasswordValid(password, _warningTextPassword)) return;
        if (InputValidator.IsFieldEmpty(confirmPassword, _warningTextConfirmPassword, "Confirm Password")) return;
        if (!InputValidator.DoPasswordsMatch(password, confirmPassword, _warningTextConfirmPassword)) return;

        _registerButton.interactable = true;
    }
}
