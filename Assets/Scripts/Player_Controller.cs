using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float JumpForce = 10f;
    private Rigidbody _rigidbody;
    private bool isOnTheGround = true;
    public bool gameOver;
    private Animator _animator;
    public float gravityModifier = 1.5f;
    public ParticleSystem explosionParitcle;
    public ParticleSystem dirtSplatter;
    public AudioClip[] jumpSounds;
    public AudioClip[] crashSounds;
    private AudioSource _audioSource;
    private int randomIdx;

    private void OnCollisionEnter(Collision othercollision)
    {
        if (othercollision.gameObject.CompareTag("obstacle"))
        {
            GameOver();
            Destroy(othercollision.gameObject);
        }
        else if (othercollision.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            dirtSplatter.Play();
        }
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        dirtSplatter.Play();
        _audioSource = GetComponent<AudioSource>();
        
    }

    private void GameOver()
    {
        gameOver = true;
        _animator.SetInteger("DeathType_int", Random.Range(1, 3));
        _animator.SetBool("Death_b", true);
        explosionParitcle.Play();
        dirtSplatter.Stop();
        ChooseRandomSFX(crashSounds);
    }

    private void jump()
    {
        isOnTheGround = false;
        _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        _animator.SetTrigger("Jump_trig");
        dirtSplatter.Stop();
        ChooseRandomSFX(jumpSounds);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && !gameOver)
        {
            jump();
        }

       
    }
    private void ChooseRandomSFX(AudioClip[] sounds)
    {
        randomIdx = Random.Range(0, sounds.Length);
        _audioSource.PlayOneShot(sounds[randomIdx], 1);
    }
}
