using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip levelMusic;
    public AudioClip winMusic;

    private void Start()
    {
        PlaySong(levelMusic);
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlaySong(levelMusic);
        }
    }

    public void PlaySong(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }
}
