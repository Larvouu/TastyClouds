using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //POUR ACCEDER AUX SCENES
using UnityEngine.UI; //POUR ACCCEDER AU TEXTE

public class GameControl : MonoBehaviour
{
    public static GameControl instance; //Pour accéder aux fonctions. 
    public float scrollSpeed = -10f;
    public GameObject gameOverText;
    public bool gameOver = false;
    public Text bestscoreText;
    public Text scoreText;
    private static float bestscore = 0;
    public float score = 0;

   // public bool menu = false;

    // Use this for initialization
    void Awake()
    {//vérifier qu'il n'y a qu'une seule instance
      //  if (menu == false)
        //{
          //  SceneManager.LoadScene("Menu");
            //menu = true;
        //}

       // else if (menu == true)
     //   {
            bestscore = PlayerPrefs.GetFloat("bestscore", bestscore);
            bestscoreText.text = "Meilleur score : " + bestscore.ToString();
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != null)
            {
                Destroy(gameObject);
            }
       // }
    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.Save();
        if (bestscore < score)
        {
            bestscore = score;
            bestscoreText.text = "Meilleur Score : " + bestscore.ToString();
            PlayerPrefs.SetFloat("bestscore", bestscore);
        }
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);/*SceneManager.LoadScene("Menu".);*/
        }
        if (scrollSpeed > -40) scrollSpeed = - 10 - score/4; /// 10;

    }

    public void FantomeScore()
    {
        if (gameOver)
        { return; }
        score++;
        scoreText.text = "Score : " + score.ToString();
    }

    public void FantomeScoreViolet()
    {
        if (gameOver) { return; }
        score += 10;
        scoreText.text = "Score : " + score.ToString();
    }

    public void FantomeMeurt()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
