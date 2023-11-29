using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAudioSource : MonoBehaviour
{
    static public NPCAudioSource Singleton;
    [SerializeField]
    private AudioSource myAudioSource;
    [SerializeField] 
    private AudioClip npcClick, npcDestroy, clickButton;

    void Awake()
    {
        Singleton = this;
    }

    public void PlayClickNPC()
    {
        myAudioSource.PlayOneShot(npcClick);
    }

    public void PlayDestroyNPC()
    {
        myAudioSource.PlayOneShot(npcDestroy);
    }

    public void PlayClick()
    {
        myAudioSource.PlayOneShot(clickButton);
    }

}


