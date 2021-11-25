using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    // プレイヤーサウンド

    /*AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip stompSound;
    public AudioClip recoverySound;
    public AudioClip gameOverSound;*/
    /*ボリューム管理のため編集*/

    public AudioSource jumpSound;
    public AudioSource damageSound;
    public AudioSource stompSound;
    public AudioSource recoverySound;
    public AudioSource gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    public void SoundJump()
    {
        //audioSource.PlayOneShot(jumpSound);
        jumpSound.Play();
    }

    public void SoundDamage()
    {
        //audioSource.PlayOneShot(damageSound);
        damageSound.Play();
    }

    public void SoundStomp()
    {
        //audioSource.PlayOneShot(stompSound);
        stompSound.Play();
    }

    public void SoundRecovery()
    {
        //audioSource.PlayOneShot(RecoverySound);
        recoverySound.Play();
    }

    public void SoundGameOver()
    {
        //audioSource.PlayOneShot(gameOverSound);
        gameOverSound.Play();
    }
}
