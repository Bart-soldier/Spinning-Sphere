using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume = 1.0f;
    [Range(.1f, 3f)]
    public float Pitch  = 1.0f;

    [HideInInspector]
    public AudioSource Source;

    public void Initialize()
    {
        Source.volume = Volume;
        Source.pitch = Pitch;
        Source.playOnAwake = false;
    }

    public void Play()
    {
        Source.Play();
    }

    public void Stop()
    {
        Source.Stop();
    }

    public void Pause(bool paused)
    {
        if (paused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
    }

    public void Pause()
    {
        Source.Pause();
    }

    public void UnPause()
    {
        Source.UnPause();
    }
}
