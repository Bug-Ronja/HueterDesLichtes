using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioSource playerHurt;
    public AudioSource playerDead;
    public AudioSource playerWalk;
    public AudioSource collect;

    private static bool sfxManExists;

    // Start is called before the first frame update
    void Start()
    {
        if (!sfxManExists)
        {
            sfxManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
