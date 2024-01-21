using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    
    public void ToggleMute()
    {
        
        AudioListener.volume = (AudioListener.volume == 0) ? 1 : 0;
    }
}
