/// <summary>
/// 
///  This class connects view scripts in ExtraAttempts with
///  APIConnection class in models 
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class APIController{

    private APIConnection _apiConnection;

    //Getter
    public APIConnection ApiConnection{
        get{
            return _apiConnection;
        }
    }
    
    /// <summary>
    /// 
    /// APIController constructor 
    /// 
    /// </summary>
    public APIController()
    {
        _apiConnection = new APIConnection();

    }
} 