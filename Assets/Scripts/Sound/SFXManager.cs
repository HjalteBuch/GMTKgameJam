using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource SFXObject;

    private void Awake() {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioClip audioClip, Vector3 spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSFXClip(AudioClip[] audioClip, Vector3 spawnTransform, float volume)
    {
        if (audioClip == null || audioClip.Length == 0) {
            return;
        }

        int rand = Random.Range(0, audioClip.Length);
        
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform, Quaternion.identity);

        audioSource.clip = audioClip[rand];

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
