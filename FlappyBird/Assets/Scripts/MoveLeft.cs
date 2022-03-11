using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    PlayerController playerRef;

    public float lowerBound;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRef.gameOver==false)
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < lowerBound && this.CompareTag("obstacle"))
            Destroy(gameObject);
        if (Input.GetKey(KeyCode.A))
            SpeedModifier();
        else
            SpeedReset();
    }

    private void SpeedReset()
    {
        speed = 20;
    }

    private void SpeedModifier()
    {
        speed = 60;
    }
}
