using Unity.VisualScripting;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public Sound Music;

    public Sound PreMusicSFX;
    public Sound PostMusicSFX;
    public Sound PauseSFX;

    void Awake()
    {
        GameController.GameStarted     .AddListener(OnGameStarted     );
        GameController.PausedToggled   .AddListener(OnPauseToggled    );
        GameAnimator  .SpawnCompleted  .AddListener(OnSpawnCompleted  );
        GameAnimator  .DespawnCompleted.AddListener(OnDespawnCompleted);

        Music       .Initialize(gameObject.AddComponent<AudioSource>());
        PreMusicSFX .Initialize(gameObject.AddComponent<AudioSource>());
        PostMusicSFX.Initialize(gameObject.AddComponent<AudioSource>());
        PauseSFX    .Initialize(gameObject.AddComponent<AudioSource>());
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
