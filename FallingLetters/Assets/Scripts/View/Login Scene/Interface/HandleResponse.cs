/// <summary>
/// 
///  This interface is implemented by the HandleLogin and HandleRegister functions.
///  The NextAction() method is decoupled from the mentioned classes and put in an
///  interface because it needed to be implemented differently and independently.
///  (Low coupling)
/// 
///  This interface is 100% hand coded.
/// 
/// </summary>
public interface HandleResponse{
    /// <summary>
    /// 
    ///  This function decides the next action based on the response retrieved by the model classes.
    ///  It shows the players whether the request was successful or not.
    /// 
    /// </summary>
    /// <param name="response"> string response returned from login or register </param>
    public void NextAction(string response);
}