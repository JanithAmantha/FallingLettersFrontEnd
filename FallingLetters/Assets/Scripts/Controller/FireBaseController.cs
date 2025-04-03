using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
///  This class connects view scripts in Login Scene with
///  FireBaseManager class in models. Objects of this class
///  access the Firebase functions on behalf of the view scripts 
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class FireBaseController{
    private FirebaseManager _firebaseManager;

    /// <summary>
    /// 
    ///  FireBaseController constructor 
    ///  Creates a firebase manager object
    /// 
    /// </summary>
    public FireBaseController()
    {
        _firebaseManager = new FirebaseManager();
    }

    /// <summary>
    /// 
    ///  Method used to check response returned from the firebase manager.
    ///  This is called in register and log in functions.
    ///  Also responsible for creating a player object.
    /// 
    /// </summary>
    /// 
    /// <param name="username"> player's username </param>
    /// <param name="token"> token given by firebase </param>
    /// <param name="expire_time"> token expiration time </param>
    /// <param name="score"> player score </param>
    /// <param name="response"> response returned </param>
    /// 
    /// <returns> returns the response as a string </returns>
    private string ResponseParser(string username, string token, long expire_time, int score,string response)
    {
        if(response =="success")
        {
            new PlayerController(token,username,score,expire_time);
            Debug.Log("new player created tho");
        }
        return response;
    }

    /// <summary>
    /// 
    ///  Method that calls the Register functionality in FirebaseManager.
    /// 
    /// </summary>
    /// 
    /// <param name="email"> email from front end </param>
    /// <param name="password"> password from front end </param>
    /// <param name="username"> username from front end </param>
    /// 
    /// <returns> returns a string returned by responseParser </returns>
    public async Task<string> RegisterUser(string email,string password,string username)
    {
        DataRegisterResponse registerResponse = await _firebaseManager.Register(email,password,username);
        return ResponseParser(username,registerResponse.token,registerResponse.expire_time,0,registerResponse.server_response);
    }

    /// <summary>
    /// 
    ///  Method that calls the Login functionality in FirebaseManager.
    /// 
    /// </summary>
    /// 
    /// <param name="email"> email from front end </param>
    /// <param name="password"> password from front end </param>
    /// 
    /// <returns> returns a string returned by responseParser </returns>
    public async Task<string> LoginUser(string email, string password)
    {
        DataLoginResponse loginResponse = await _firebaseManager.Login(email,password);
        return ResponseParser(loginResponse.username,loginResponse.token,loginResponse.expire_time,loginResponse.score,loginResponse.server_response);
    }

    /// <summary>
    /// 
    ///  Method is used to fetch playerData in leaderboard
    /// 
    /// </summary>
    /// 
    /// <param name="token"> token given to player by firebase to verify the user </param>
    /// 
    /// <returns> returns a list of players </returns>
    public async Task<List<DataGetUsers>> GetPlayerData(string token)
    {
        return await _firebaseManager.GetLeaderboard(token);
    }

    /// <summary>
    /// 
    ///  Used to update the score when user hits a new highs core
    ///  Called by scripts in GameOver Scene
    /// 
    /// </summary>
    /// 
    /// <param name="score"> new high score </param>
    /// <param name="token"> token to verify the user </param>
    public async Task UpdateScore(int score, string token)
    {
        await _firebaseManager.UpdateScore(score,token);
    }

    /// <summary>
    /// 
    ///  Method is used to connect the views with ForgetPassword() function
    ///  in the models.
    /// 
    /// </summary>
    /// 
    /// <param name="email"> users email entered by the user </param>
    public async Task <string> ConnectForgetPassword(string email)
    {
        return await _firebaseManager.DataForgetPassword(email);
    }

}