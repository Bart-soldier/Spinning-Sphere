using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource Music;

    public AudioSource PreMusicSFX;
    public AudioSource PostMusicSFX;
    public AudioSource PauseSFX;

    void Awake()
    {
        GameController.GameStarted     .AddListener(OnGameStarted     );
        GameController.PausedToggled   .AddListener(OnPauseToggled    );
        GameAnimator  .SpawnCompleted  .AddListener(OnSpawnCompleted  );
        GameAnimator  .DespawnCompleted.AddListener(OnDespawnCompleted);
    }

    private void OnGameStarted()
    {
        PreMusicSFX.Play();
    }

    private void OnSpawnCompleted()
    {
        Music.Play();
    }
    private void OnDespawnCompleted()
    {
        Music.Stop();
        PostMusicSFX.Play();
    }


    private void OnPauseToggled(bool paused)
    {
        if(paused)
        {
            Music.Pause();
            PauseSFX.Play();
        }
        else
        {
            Music.UnPause();
            PauseSFX.Play();
        }
    }
}
