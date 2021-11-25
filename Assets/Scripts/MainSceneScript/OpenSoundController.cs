using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSoundController : MonoBehaviour
{
    public AudioSource openSound;

    public void PlayOpenSound()
    {
        openSound.Play();
    }
}
