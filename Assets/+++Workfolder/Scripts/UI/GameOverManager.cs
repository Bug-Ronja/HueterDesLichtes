using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * GameOver verwaltet operationen über Buttons in Scene 'Game Over'
 */

public class GameOverManager : MonoBehaviour
{

    // Wenn der Button 'Quit' angeklickt wird, wird das Spiel beendet
    public void Quit()
    {
        Application.Quit();
    }
}
