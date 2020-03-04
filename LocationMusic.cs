using XrCore;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LocationMusic : MonoBehaviour
{
    private int hour;
    private AudioSource audioManager;
    private AudioClip currentSound;
    [HideInInspector]
    public float soundVolume = 0.2f;
    private float progress = 0.2f;

    public AudioClip day;
    public AudioClip night;
    
    public static LocationMusic Instance;

    private void Awake()
    {
        Instance = this;
        audioManager = GetComponent<AudioSource>();
    }

    void Start()
    {
        hour = (int)DataTime.hour;
        audioManager.volume = soundVolume;
        audioManager.clip = GetCurrentSound();
        audioManager.Play();
    }

    public void PlaySound()
    {
        hour = (int)DataTime.hour;
        StartCoroutine(LocationSound());
    }

    IEnumerator LocationSound()
    {
        currentSound = GetCurrentSound();
        if(currentSound.name != audioManager.clip.name)
        {
            progress = 0.2f;
            while (progress > 0)
            {
                progress -= Time.deltaTime / 10f;
                audioManager.volume = progress;
                yield return null;
            }
            audioManager.clip = currentSound;
            audioManager.Play();
            while (progress < 0.2f)
            {
                progress += Time.deltaTime / 10f;
                audioManager.volume = progress;
                yield return null;
            }
        }
    }

    AudioClip GetCurrentSound() 
    {
        AudioClip audio;
        if (hour >= 7 && hour < 22) audio = day;
        else audio = night;
        return audio;
    }
}
