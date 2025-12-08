using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public AudioSource goodAudioSource;
    public AudioSource badAudioSource;
    public AudioSource botonSource;

    public void GoodPlay()
    {
        goodAudioSource.Play();   
    }
    public void BadPlay()
    {
        badAudioSource.Play();
    }

    public void BotonPlay()
    {
        botonSource.Play();
    }
}
