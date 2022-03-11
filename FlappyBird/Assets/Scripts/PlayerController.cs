using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioSource playerAudio;

    public float jumpForce;
    public float gravityModifier;
    bool isGrounded;
    int jumpCheck;
    public bool gameOver;

    public float runSpeedModifier;
    bool timer;

    public float forwardSpeed;
    public float maxLimit;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio=GetComponent<AudioSource>();
        playerRb = gameObject.GetComponent<Rigidbody>();
        //playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        isGrounded = true;
        gameOver = false;
        jumpCheck = 0;
        //playerAnim.SetFloat("Speed_f", 0.1f);
        timer = false;
        //Invoke(nameof(TimerOff), 1f);
    }

   

    // Update is called once per frame
    void Update()
    {
        if (InScreenCheck())
            SetYPosition();        
        else if (MovementCheck())
        {
            Jump();
           // playerRb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
        }
        
        
    }

    private bool InScreenCheck()
    {
        if (transform.position.y > maxLimit)
            return true;
        else 
            return false;

    }
    void SetYPosition()
    {
        transform.position = new Vector3(transform.position.x, maxLimit, transform.position.z);

    }
    bool MovementCheck()
    {
        if (Input.GetKey(KeyCode.Space) && !gameOver)
            return true;
        else
            return false;
    }


    void Jump()
    {
        isGrounded = false;
        jumpCheck++;
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
        
        playerAudio.PlayOneShot(jumpSound, 1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            if (!gameOver)
            dirtParticle.Play();

        }
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("game over");
            gameOver = true;
            
            explosionParticle.Play();
            playerAudio.PlayOneShot(hitSound, 1.0f);
        }

    }
}
