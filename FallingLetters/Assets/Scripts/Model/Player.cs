/// <summary>
/// 
///  Class that represents the Players of the game.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class Player
{
    private string _token;
    private string _username;
    private int _score;
    private long _expTime;

    //Getters
    public string Token{
        get{
            return _token;
        }
    }

    public string Username{
        get{
            return _username;
        }
    }
    public long ExpTime{
        get{
            return _expTime;
        }
    }

    //Getter and Setter
    public int Score{
        get{
            return _score;
        }
        set{
            _score = value;
        }
    }
    
    /// <summary>
    /// 
    ///  Player constructor.
    /// 
    /// </summary>
    /// 
    /// <param name="token"> token returned by server </param>
    /// <param name="username"> username returned by database </param>
    /// <param name="score"> score returned by database </param>
    /// <param name="exp"> token expiration time returned by server </param>
    public Player(string token, string username, int score,long exp)
    {
        this._token = token;
        this._username = username;
        this._score = score;
        this._expTime = exp;
    }

}