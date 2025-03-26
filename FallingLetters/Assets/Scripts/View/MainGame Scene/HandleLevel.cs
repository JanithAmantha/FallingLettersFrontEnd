using UnityEngine;

/// <summary>
/// 
///  This class is responsible for assigning gravity to falling letters
///   in MainGame when the level increases.This class is attached to 
///  all falling letter objects in MainGame.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleLevel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    /// <summary>
    /// 
    ///  Assigns gravity as it increases to each falling letter object.
    /// 
    /// </summary>
    private void Start()
    {
        _rigidbody2D.gravityScale = HandleGameLogic.Instance.LevelUp();
        Debug.Log(_rigidbody2D.gravityScale);
    }
}