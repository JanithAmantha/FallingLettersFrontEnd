using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  The core of the game that manages scores, attempts and level up.
///  Follows Singleton design pattern.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleGameLogic : MonoBehaviour
{
    [SerializeField] private GameObject[] _hearts;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private static HandleGameLogic _instance;
    private int _collisionCount = 0;
    private int _temporaryScore = 0;
    private int _attemptCount=3;
    private int _score;
    private float _gravityIncreased = 0.5f;
    private int _level = 1;

    //Getters
    public int Score{
        get{
            return _score;
        }
    }

    /* Responsibility of TemporaryScore is to make sure the Level up occurs smoothly.*/
    public int TemporaryScore{
        get{
            return _temporaryScore;
        }
        set{
            _temporaryScore = value;
        }
    }

    public int Level{
        get{
            return _level;
        }
        set{
            _level = value;
        }
    }

    public int AttemptCount{
        get{
            return _attemptCount;
        }
    }
    
    public static HandleGameLogic Instance{
        get{
            return _instance;
        }
    }

    public float GravityIncreased{
        get{
            return _gravityIncreased;
        }
        set{
            _gravityIncreased = value;
        }
    }

    /// <summary>
    /// 
    ///  Awake is the first method that is called even before the start function.
    ///  Awake can run even when the object is disabled.
    ///  Purpose of this function is to maintain the Singleton pattern and to keep this instance active 
    ///  to make sure there only exists one instance of this class. If more instances of the game core
    ///  existed, it would cause troubles for the flow of the game as this controls most parts of 
    ///  the game. 
    ///  This instance stays active even during some Scene transitions. Instance is only destroyed
    ///  when the game is over or when an error occurs.
    /// 
    /// </summary>
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// 
    ///  Responsible for removing attempts when a mistake is made.
    ///  Each player is allowed to make 3 mistakes and they can extend
    ///  the number of attempts by playing the banana game.
    ///  
    ///  If user makes 7 mistakes this function ends the game.
    /// 
    /// </summary>
    public void RemoveHeart()
    {

        Debug.Log("Collision count : "+_collisionCount);
        if (_collisionCount < _hearts.Length) //there are 3 hearts
        {
            Destroy(_hearts[_collisionCount++]); 
        }
        else if (_collisionCount<6)
        {
            _attemptCount--;
            SceneManager.LoadScene("ExtraAttempts");
            _collisionCount++;
        }
        else{
            GameOver();
        }
    }

    /// <summary>
    /// 
    ///  This function is used when players obtain scores.
    //   Plays an audio clip whenever a player obtains a score and increases the score by 1.
    /// 
    /// </summary>
    public void SetScore()
    {
        _audioSource.PlayOneShot(_audioClip);
        _score++;
    }

    /// <summary>
    /// 
    ///  Responsible for resetting values, passing data and 
    ///  loading the GameOver Scene when the attempts run out.
    /// 
    /// </summary>
    public void GameOver()
    {
        PlayerPrefs.SetFloat("LastScore", _score);
        PlayerPrefs.Save();
        DestroyObject();
        SceneManager.LoadScene("GameOver");
    }

    /// <summary>
    ///
    ///  To Destroy Game Logic Objects when switching to other scenes 
    /// 
    /// </summary>
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }    
}