using UnityEngine;

/// <summary>
/// 
///  Class responsible for handling letter collisions
///  when letters collide with the spikes.This class is attached to 
///  all falling letter objects in MainGame.
/// 
///  This class is 100% hand coded.
/// 
/// </summary>
public class HandleCollision  : MonoBehaviour
{

    private int _collisionLock=0;
 
    /// <summary>
    /// 
    ///  Responsibility of this function is to identify that the letters have collided with spikes
    ///  and call the RemoveHearts() method in game logic to reduce attempts of the player.
    /// 
    /// </summary>
    /// 
    /// <param name="other"> The other object which collided with this object </param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "DangerZone")
        {
            _collisionLock++;
            /* Each spike in spikes cause 2D Collisions. This method is executed the moment when a collision occurs.
            When multiple collisions happen at once this method is executed multiple times which will lead to game over
            within a single mistake. _collisionLock exists to prevent that. It makes sure the method is successfully 
            executed only in the first collision. */
            Destroy(this.gameObject);
            if(_collisionLock==1)
            {
                HandleGameLogic.Instance.RemoveHeart();
            }

        }
        
    }

}