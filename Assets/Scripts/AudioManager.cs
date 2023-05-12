using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundSoundSource;
    [SerializeField]
    private AudioSource soundClipSource;


    public static AudioManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(AudioClip clip)
    {
        soundClipSource.PlayOneShot(clip);
    }

    public void PlayBackground()
    {
        backgroundSoundSource.Play();
    }

    private void Start()
    {

    }

}

