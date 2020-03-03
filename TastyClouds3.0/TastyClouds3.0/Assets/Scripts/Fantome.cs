using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantome : MonoBehaviour {

    public static Fantome instance;

    protected bool estMort = false;
    protected PolygonCollider2D bc2d;
    protected Rigidbody2D rb2d;
    protected Animator anim;
  

 //   private float upForce = 400f;

    void Awake()
    {//vérifier qu'il n'y a qu'une seule instance
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        bc2d = GetComponent<PolygonCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!estMort)
        { /*
           if(Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            } */
            if (rb2d.transform.position.y <= -9)
            {
                //bouger le fantome;
               // rb2d.velocity = new Vector2(0, -10);
                this.transform.position = new Vector2(-10, 8);
            }

            if (rb2d.transform.position.y >= 9)
            {
                this.transform.position = new Vector2(-10, -8);
            }
            
            if (Input.GetMouseButton(0))
            {
              
                if (Input.mousePosition.y >= Screen.height/2)
                {
                    rb2d.transform.position = new Vector2(-10, rb2d.transform.position.y + 0.2f);
                }
                if (Input.mousePosition.y < Screen.height/2)
                {
                    rb2d.transform.position = new Vector2(-10, rb2d.transform.position.y - 0.2f); 
                }
            }
        }
	}
    
    public void setEstMortTrue()
    {
        this.estMort = true;
    }

    public void forceDefaite()
    {
        rb2d.AddForce(new Vector2(-1000, 0));
    }

    public void AnimMort()
    {
        anim.SetTrigger("Mort");
    }

    public void AnimMange()
    {
        anim.SetTrigger("Mange");
    }
}
