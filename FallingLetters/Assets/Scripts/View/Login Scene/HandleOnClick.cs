using UnityEngine;

/// <summary>
/// 
///  Implements HandleButtonClick interface.
///  Handle panel transition on button clicks.
///  Responsible for panel transition upon a button click.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleOnClick : MonoBehaviour, HandleButtonClick{
    [SerializeField] private GameObject _nextPanel;
    public void OnClick()
    {
        HandlePanelTransition.Instance.SpawnPanel(_nextPanel);
    }

}
