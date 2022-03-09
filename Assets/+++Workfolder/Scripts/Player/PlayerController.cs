using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerController verhindert das es zwei Player in einem Level gibt,
 * gibt die Steuerung vor und animiert den Palyer
 */

public class PlayerController : MonoBehaviour
{
    public string startPoint;                          // gibt den Start-Punkt des Players an
    public float moveSpeed = 5f;                       // gibt die Bewegungsgeschwindigkeit des Players an
    public Transform movePoint;                        // beinhaltet den MovePoint, dem der Player folgt
    public LayerMask whatStopsMovement;                // beinhaltet Layer-Maske, welche den Palayer am bewegen hindert
    public Vector2 movement;                           // beinhaltet das Movement
    public Animator animator;                          // beinhaltet den Animator
    public int amuletBig = 20;                         // Punkte, die das große Amulett wiederherstellt 
    public int amuletSmall = 10;                       // Punkte, die das kleine Amulett wiederherstellt 
    public Light playerLight;                          // beinhaltet das Licht vom Spieler
    public static PlayerController instance = null;    // damit andere Skripte auf den PlayerController zugreifen können
    public int keyCounter = 0;                         // Counter für die Schlüssel

    private static bool playerExists;                  // gibt an, ob Player exestiert
    private static bool movePointExists;               // gibt an, ob MovePoint exestiert
    private SFXManager sfxMan;                         // beinhaltet den SFXManager

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // entfernt den movePoint als Child des Players
    //sichert, das Player nur einmal in dem Level vorhanden ist
    // sichert, das movePoint nur einmal im Level vorhanden ist
    private void Start()
    {
        
        movePoint.parent = null;

        playerLight.range = PlayerHealthManager.instance.playerCurrentHealth;

        sfxMan = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (!movePointExists)
        {
            movePointExists = true;
            DontDestroyOnLoad(movePoint);
        }
        else
        {
            Destroy(movePoint);
        }
    }

    // Update is called once per frame
    // implementiert die Steuerung an das Grid gebunden und in nur 4 richtungen
    // wenn sich diagonal bewegt werden möchte, wird dies als horizontale Bewegung interpretiert
    // animiert den Player
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    sfxMan.playerWalk.Play();
                }
            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    sfxMan.playerWalk.Play();
                }
            }
        }

        if (keyCounter == 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("Gate"));
            Destroy(GameObject.FindGameObjectWithTag("Boss"));
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    // OnTriggerEnter2D führt verschiedene Operationen aus
    // Operationen werden anhand des Tags des GameObjects ausgewählt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AmuletBig")
        {
            PlayerHealthManager.instance.playerCurrentHealth += amuletBig;
            collision.gameObject.SetActive(false);
            playerLight.range = PlayerHealthManager.instance.playerCurrentHealth;
            sfxMan.collect.Play();
        } 
        else if (collision.tag == "AmuletSmall")
        {
            PlayerHealthManager.instance.playerCurrentHealth += amuletSmall;
            collision.gameObject.SetActive(false);
            playerLight.range = PlayerHealthManager.instance.playerCurrentHealth;
            sfxMan.collect.Play();
        }
        else if(collision.tag == "Despawner")
        {
            collision.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            sfxMan.collect.Play();
        }
        else if (collision.tag == "Shield")
        {
            collision.gameObject.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            PlayerHealthManager.instance.playerCurrentHealth += amuletBig;
            playerLight.range = PlayerHealthManager.instance.playerCurrentHealth;
            sfxMan.collect.Play();
        }
        else if (collision.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            keyCounter++;
            sfxMan.collect.Play();
        }
    }

}
