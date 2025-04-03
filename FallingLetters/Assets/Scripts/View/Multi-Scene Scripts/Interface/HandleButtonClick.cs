/// <summary>
/// 
///  This interface is implemented by multiple scenes.
///  Decoupled all onClick functions so they can be executed independently.
/// 
///  This interface is 100% hand coded.
/// 
/// </summary>
public interface HandleButtonClick{
    /// <summary>
    /// 
    ///  This function is always assigned to an onClick function of a button.
    ///  To perform something upon clicking a button.
    /// 
    /// </summary>
    public void OnClick();
}