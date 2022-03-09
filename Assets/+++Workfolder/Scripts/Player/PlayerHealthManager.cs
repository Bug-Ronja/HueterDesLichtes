using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * PlayerHealthManager für aktualisierung der Lebenspunkte des Players 
 */
public class PlayerHealthManager : MonoBehaviour
{

    public int playerMaxHealth;                          // gibt an, welches die maximale Kapazität der Lebenspunkte ist
    public int playerCurrentHealth;                      // gibt die momentane Lebensanzeige des Player an
    public int playerStartHealth;                        // gibt die Lebenspunkte an, mit welchen der Player startet
    public static PlayerHealthManager instance = null;   // damit andere Skripte auf den HealthManager zugreifen können

    private SFXManager sfxMan;                           // beinhaltet den SFXManager
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    // setzen der PlayerHealthPoints auf maximale Punkte
    void Start()
    {
        playerCurrentHealth = playerStartHealth;
        PlayerController.instance.playerLight.range = playerCurrentHealth;
        sfxMan = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    // Überprüfung, ob Player GameOver ist
    // Verhindert das Player über 200 LP hat
    void Update()
    {
        if(playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            sfxMan.playerDead.Play();
            SceneManager.LoadScene("GameOver");
        } 
        else if(playerCurrentHealth > 200)
        {
            playerCurrentHealth = 200;
        }
    }

    // zieht HelthPoints ab wenn Palyer in einen Gegner rein läuft
    public void HurtPlayer(int damage)
    {
        playerCurrentHealth -= damage;
        PlayerController.instance.playerLight.range = playerCurrentHealth;
        sfxMan.playerHurt.Play();
    }

}
