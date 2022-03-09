using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * EnemyController für Movement der Gegner zuständig
 * die Bewegungsrichtung und Abstände zwischen den Bewegungen erfolgen random
 */

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public float timeBetweenMove;
    public float timeToMove;
    public float waitToReload;

    private Rigidbody2D rb;
    private bool moving;
    private Vector3 moveDirection;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private bool reloading;
    private GameObject player;

    // Start is called before the first frame update
    // Generiert die Random-Werte zum Bewegen der Gegner
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rb.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        } 
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1) * moveSpeed, 0f);
            }
        }
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0f)
            {
                Application.LoadLevel(Application.loadedLevel);
                player.SetActive(true);
            }
        }
        
    }
}
