using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicAudioSource;
    [SerializeField]
    private AudioSource SFXSource;

    public AudioClip music;
    public AudioClip[] footSteps;
    public AudioClip steps;
    public AudioClip death;
    public AudioClip consumeHolyFlame;
    public AudioClip Attacking;
    public AudioClip enemyAttack;
    public AudioClip toxicSpores;
    public AudioClip victory;
    public AudioClip defeat;

    private void Start()
    {
        musicAudioSource.clip = music;
        musicAudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
