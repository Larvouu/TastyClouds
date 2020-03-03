using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuageNoir : MonoBehaviour
{

    private Animator anim;
    //private Rigidbody2D rb2d; //inutilisé
    // Use this for initialization
    void Start()
    {
       // rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Vector2.Distance(transform.position, Fantome.instance.transform.position) <= 1f)
        {
            anim.SetTrigger("Intermediaire");
        }
        */
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Fantome>() != null)
        {
            Sound_Manager.Playsound("GameOver");

            GameControl.instance.FantomeMeurt();
            Fantome.instance.setEstMortTrue();
            Fantome.instance.forceDefaite();
            Fantome.instance.AnimMort();

            anim.SetTrigger("Intermediaire");
            
        }
    }

   


}
