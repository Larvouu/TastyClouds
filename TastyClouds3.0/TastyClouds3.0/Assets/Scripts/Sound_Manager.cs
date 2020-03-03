using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour {
    public static AudioClip deathSound, scoreSound;
    static AudioSource audiosrc;

	// Use this for initialization
	void Start () {
        deathSound = Resources.Load<AudioClip>("GameOver");
        scoreSound = Resources.Load<AudioClip>("Eat");

        audiosrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Playsound (string clip)
    {
        switch(clip)
        {
            case "GameOver":
                audiosrc.PlayOneShot(deathSound);
                Debug.Log("Fonctionne");
                break;
            case "Eat":
                audiosrc.PlayOneShot(scoreSound);
                Debug.Log("Fonctionne");
                break;
        }
    }
}
