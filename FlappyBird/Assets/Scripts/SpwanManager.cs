using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{

    public Transform spawnPosition;
    public GameObject obstaclePrefab;
    //public GameObject[] obstaclePrefab;

    public float startDelay;
    public float repeatDelay;

    PlayerController playerRef;


    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("InstantiateObstacle", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateObstacle()
    {
        int obsPositionY = Random.Range(-1, 3);
        if (playerRef.gameOver == false)
            Instantiate(obstaclePrefab, new Vector3(spawnPosition.position.x, obsPositionY, spawnPosition.position.z), Quaternion.identity);
    }

}
