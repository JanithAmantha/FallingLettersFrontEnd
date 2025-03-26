using UnityEngine;

/// <summary>
/// 
///  The class responsible for handling audio effects
///  when letters collide with the spikes.This class is attached to 
///  all falling letter objects.
/// 
///  This class is 100% hard coded.
/// 
/// </summary>
public class HandleCollideAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
 
    /// <summary>
    /// 
    ///  Plays the audio clip when the letters are collided.
    ///  Automatically called when a collision event occurs.
    /// 
    /// </summary>
    /// 
    /// <param name="other"> The other object which collided with this object </param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        _audioSource.PlayOneShot(_audioClip);
        
    }

}
