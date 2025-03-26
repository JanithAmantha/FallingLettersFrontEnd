using UnityEngine;

/// <summary>
/// 
///  This class is responsible for Destroying HandleGameLogic Instance
///  incase an unexpected scene transition occurs. 
///  Attached to multiple scenes.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleInstanceDestroy : MonoBehaviour
{
    /// <summary>
    /// 
    ///  Destroys the HandleGameLogic Instance upon start.
    /// 
    /// </summary>
    private void Start()
    {
        if(HandleGameLogic.Instance !=null)
            HandleGameLogic.Instance.DestroyObject();   
    }
}