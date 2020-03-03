using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuageViolet : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Animator anim;
    private int timer = 0;

    private bool monte = true;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(monte == true && this.transform.position.y <= 6 && this.transform.position.y > -6)
        {
            rb2d.transform.position = new Vector2(rb2d.transform.position.x, rb2d.transform.position.y + 0.1f);
            if(this.transform.position.y > 5.5f)
            {
                monte = false;
            }
        }
        if (monte == false && this.transform.position.y <= 6 && this.transform.position.y > -6)
        {   
            rb2d.transform.position = new Vector2(rb2d.transform.position.x, rb2d.transform.position.y - 0.1f);
            if (this.transform.position.y < -5.5f)
            {
                monte = true;
            }
        }
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
            GameControl.instance.FantomeScoreViolet();
            Fantome.instance.AnimMange();
            anim.SetTrigger("Aspire");
            timer = 1;
        }
    }
}
