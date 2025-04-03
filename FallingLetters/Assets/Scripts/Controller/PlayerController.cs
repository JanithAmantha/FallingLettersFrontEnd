/// <summary>
/// 
///  class that manages player objects and connect views with the
///  player object
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class PlayerController{

    private static Player _player= null;

    //Getter
    public static Player Player{
        get{
            return _player;
        }
    }

    /// <summary>
    /// 
    ///  PlayerController construct
    ///  Used to create a player object.
    /// 
    /// </summary>
    /// 
    /// <param name="token"> token received by firebase </param>
    /// <param name="name"> players name </param>
    /// <param name="score"> players highest score </param>
    /// <param name="exp"> token expiration time </param>
    public PlayerController(string token,string name, int score, long exp)
    {
        _player = new Player(token,name,score,exp);
    }

    /// <summary>
    /// 
    ///  This method is used when the user is logged out to make 
    ///  the player object null.
    /// 
    /// </summary>
    public static void LogOut()
    {
        _player = null;
    }
}