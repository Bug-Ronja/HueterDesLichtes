using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PauseMenuManager für Funktionalität Pasenmenü zuständig
 */

public class PauseMenuManager : MonoBehaviour
{

    public static bool isPaused = false;     // gibt an, ob Pausen Menü aktiv oder inaktiv ist
    public GameObject pauseMenuUI;           // Pausen Menü UI 

    private static bool UIExists;            // gibt an, ob PausenMenü UI exestiert

    // Pausenmenü am Anfang auf false gesetzt
    // wird Überprüft, ob Pausen Menü schon vorhanden ist
    void Start()
    {
        pauseMenuUI.SetActive(false);

        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    // Wenn ESC das erste Mal gedrückt wird, wird UI angezeigt
    // Wenn ESC das zweite Mal gedrückt wird, wird UI deaktiviert
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    // Pausenmenü false gesetzt
    // Zeit läuft normal weiter
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Pausenmenü true gesetzt
    // Zeit wird angehalten
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
