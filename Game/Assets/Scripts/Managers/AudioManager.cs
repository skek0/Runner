using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource effectAudioSource;
    [SerializeField] AudioSource sceneryAudioSource;

    public void Listen(AudioClip audioclip)
    {
        effectAudioSource.PlayOneShot(audioclip);
    }
}
