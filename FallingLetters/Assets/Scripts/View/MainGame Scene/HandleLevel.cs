using UnityEngine;

/// <summary>
/// 
///  This class is responsible for assigning gravity to falling letters
///   in MainGame when the level increases.This class is attached to 
///  all falling letter objects in MainGame.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleLevel : MonoBehaviour
{
    private int _score;
    
    /* This lock is to make sure that level up only occurs once in every 10 scores player gets. */
    private bool _levelLock = false;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    /// <summary>
    /// 
    ///  Assigns gravity as it increases to each falling letter object.
    /// 
    /// </summary>
    private void Awake()
    {
        _score= HandleGameLogic.Instance.Score;
        UnlockLevel();
        _rigidbody2D.gravityScale = LevelUp();
        Debug.Log(_rigidbody2D.gravityScale);
    }

    /// <summary>
    /// 
    ///  Every time a player gets a score thats divisible by 10
    ///  The gravity of falling letters is increased by 0.2. Each increment
    ///  in gravity is considered a level up. This function is responsible 
    ///  for the level up task and increase in gravity.
    /// 
    /// </summary>
    /// 
    /// <returns> increased gravity number </returns>
    private float LevelUp()
    {
        Debug.Log(_score);
        if((_score % 10 == 0)&&(_score > 10)&&_levelLock)
        {
            HandleGameLogic.Instance.Level++;
            HandleGameLogic.Instance.GravityIncreased += (float)0.2;
        }

        return HandleGameLogic.Instance.GravityIncreased;
    }

    /// <summary>
    /// 
    ///  Responsibility is to make sure that level up only occurs once when score reaches a number that is divisible by 10.
    ///  Without this function the level up will occur multiple times as new falling letter objects are generated which will
    ///  cause level to reach from 1 to somewhere like 5 suddenly.
    /// 
    /// </summary>
    private void UnlockLevel()
    {
        if((HandleGameLogic.Instance.TemporaryScore < _score)&&(_score % 10 == 0)&&(_score > 10))
        {
            HandleGameLogic.Instance.TemporaryScore = _score;
            _levelLock = true;
        }
    }
}