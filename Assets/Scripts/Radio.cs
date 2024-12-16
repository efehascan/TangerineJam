using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public static Radio Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private int currentClipIndex = 0;

    private void Awake()
    {
        // Singleton deseniyle sahne değişse bile nesnenin yok olmamasını sağlıyoruz
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (audioClips.Length > 0)
        {
            PlayCurrentClip();
        }
    }

    public void PlayCurrentClip()
    {
        if (audioClips.Length == 0 || currentClipIndex >= audioClips.Length) return;

        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();
    }

    public void PlayNextClip()
    {
        currentClipIndex++;
        if (currentClipIndex < audioClips.Length)
        {
            PlayCurrentClip();
        }
        else
        {
            currentClipIndex = 0; // Sona geldiğinde başa dönebilir
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
