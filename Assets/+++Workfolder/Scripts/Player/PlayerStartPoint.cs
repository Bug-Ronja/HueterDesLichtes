using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerStartPoint nur zum versetzen des Player zum Spawnpunkt des neuen Levels
 */

public class PlayerStartPoint : MonoBehaviour
{

    public string pointName;                                // gibt an, welcher Punkt der Start-Punkt vom Player ist

    private PlayerController player;                        // beinhaltet den Player

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if(player.startPoint == pointName)
        {
            player.transform.position = transform.position;
        }
    }
}
