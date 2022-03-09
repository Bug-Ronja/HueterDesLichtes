using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MovePointStartPoint nur zum versetzen des MovePoints zum Spawn-Punkt des neuen Levels
 */
public class MovePointStartPoint : MonoBehaviour
{

    public string pointName;                                    // gibt den Start-Punkt des Movepoints an

    private MovePointController movePoint;                      // beinhaltet den MovePoint

    // Start is called before the first frame update
    void Start()
    {
        movePoint = FindObjectOfType<MovePointController>();

        if(movePoint.startPoint == pointName)
        {
            movePoint.transform.position = transform.position;
        }
    }
}
