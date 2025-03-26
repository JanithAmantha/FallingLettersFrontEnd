using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  The core of the game that manages scores, attempts and level up.
///  Follows Singleton design pattern.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleGameLogic : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _attempts;
    [SerializeField] private GameObject[] _hearts;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private static HandleGameLogic _instance;
    [SerializeField] private TMP_Text _levelText;
    private static int _collisionCount = 0;
    private int _attemptCount=3;
    private static int _score;
    private float _gravityIncreased = 0.5f;
    private int _level = 1;

    //Getters
    public int Score{
        get{
            return _score;
        }
    }
    
    public static HandleGameLogic Instance{
        get{
            return _instance;
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
    ///  Responsibility of this Update function is to display texts to users the moment they change.
    ///  (attempts, level, score)
    /// 
    /// </summary>
    private void Update()
    {
        _attempts.SetText(_attemptCount.ToString());
        _scoreText.SetText("Score : "+_score.ToString());
        _levelText.SetText(_level.ToString());
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
    ///  This function is used to reset all the values 
    ///  when the game is over.
    /// 
    /// </summary>
    private void ResetValues()
    {
        _score=0;
        _collisionCount=0;
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
    public float LevelUp()
    {
        Debug.Log(_score);
        if((_score % 10 == 0)&&(_score > 10))
        {
            _level++;
            _gravityIncreased += (float)0.2;
        }

        return _gravityIncreased;
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
        ResetValues();
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver");
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
    
}


