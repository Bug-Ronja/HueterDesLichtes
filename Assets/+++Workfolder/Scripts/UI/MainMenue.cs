using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * MainManue verwaltet die Button Operationen in der Scene 'MainManue'
 */
public class MainMenue : MonoBehaviour
{

    // Wenn der Button 'Start Game' angeklickt wird, startet das Spiel
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // Wenn der Button 'Quit' angeklickt wird, wird das Spiel beendet
    public void QuitGame()
    {
        Application.Quit();
    }

    // Wenn der Button 'Credits' angeklickt wird, werden die Credits angezeigt
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
 
}
