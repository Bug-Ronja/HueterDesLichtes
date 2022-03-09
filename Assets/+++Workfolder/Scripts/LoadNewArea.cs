using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * LoadNewArea für den Wechsel zum anderen Level zuständig
 */

public class LoadNewArea : MonoBehaviour
{
    // levelToLoad wird jedem Portal als String übergeben, ist name von Scene, welche geladen werden soll
    // exitPoint wird als String übergeben
    public string levelToLoad;
    public string exitPoint;
    // Player und Movepoint "objekt"
    private PlayerController player;
    private MovePointController movePoint;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        movePoint = FindObjectOfType<MovePointController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            // startPoint von player und movePoint wird gleich exitPoint gesetzt, damit verschiedene start-
            // und exitPoint exestieren können
            player.startPoint = exitPoint;
            movePoint.startPoint = exitPoint;
            // reset keyCounter, damit Gate in neuer Scene nicht direkt geöffnet wird
            PlayerController.instance.keyCounter = 0;
        }
    }

}
