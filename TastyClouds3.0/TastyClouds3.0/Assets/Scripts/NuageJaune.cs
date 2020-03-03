using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuageJaune : MonoBehaviour {

    private Animator anim;
    private int timer = 0;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0) timer++;
        if (timer == 15)
        {
            this.transform.position = new Vector2(this.transform.position.x, -20);
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Fantome>() != null)
        {
            Sound_Manager.Playsound("Eat");
            GameControl.instance.FantomeScore();
            Fantome.instance.AnimMange();

            anim.SetTrigger("Aspire");
            timer = 1;
            
        }
       
    }
}
