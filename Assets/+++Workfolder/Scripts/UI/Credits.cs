using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Credits verwaltet die Button Operationen in der Scene 'Credits'
 */

public class Credits : MonoBehaviour
{

    // Wenn der Button 'Back' angeklickt wird, kommt man ins Main Menü
    public void Back()
    {
        SceneManager.LoadScene("MainMenue");
    }
}
