using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * IUManager ist für die Lebensanzeige zuständig
 */

public class IUManager : MonoBehaviour
{

    public Slider lightBar;                  // Slider für die Lebensanzeige
    public Text lightText;                   // Text unter der Lebensanzeige
    public PlayerHealthManager playerHealth; // verbindung zum PlayerHealthManager

    private static bool UIExists;

    // Start is called before the first frame update
    // Verhindert, dass mehr als eine Lebensanzeige vorhanden ist
    // sorgt dafür, dass Lebensanzeige mit in weitere Level mitgenommen wird
    void Start()
    {
        if(!UIExists)
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
    // Aktualisiert die Lebensanzeige
    void Update()
    {
        lightBar.maxValue = playerHealth.playerMaxHealth;
        lightBar.value = playerHealth.playerCurrentHealth;
        lightText.text = "Light: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
    }
}
