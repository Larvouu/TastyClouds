using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlacementNuages : MonoBehaviour
{
    private Vector2 objectPoolPosition = new Vector2(-15, 15);
    private float spawnXPosition = 20f;
    private float spawnYPosition;
    public GameObject nuageJaunePrefab;
    public GameObject nuageNoirPrefab;
    public GameObject nuageVioletPrefab;
    public int nuagePoolSize = 5;               //Taille du tableau de nuages
    public float spawnRate = 3f;
    public float nuageMin = -10f;
    public float nuageMax = 10f;

    public float RandNuage;

    private GameObject[] nuages;
    private int currentNuage = 0;               //Index du current Nuage dans la collection

    void Start()
    {
        nuages = new GameObject[nuagePoolSize];
        for (int i = 0; i < 5; i++)
        {
            nuages[i] = (GameObject)Instantiate(nuageJaunePrefab, new Vector2((-10 + i*10), -20), Quaternion.identity);
        }
    }


    void Update()
    {
        if(nuages[currentNuage].transform.position.x < -30 && GameControl.instance.gameOver == false)
        {
            DestroyObject(nuages[currentNuage]);
            RandNuage = Random.Range(0, 100);
            if (RandNuage < 10) nuages[currentNuage] = (GameObject)Instantiate(nuageVioletPrefab, objectPoolPosition, Quaternion.identity);
            if (RandNuage <= 55 && RandNuage >= 10) nuages[currentNuage] = (GameObject)Instantiate(nuageJaunePrefab, objectPoolPosition, Quaternion.identity);
            if (RandNuage <= 100 && RandNuage > 55) nuages[currentNuage] = (GameObject)Instantiate(nuageNoirPrefab, objectPoolPosition, Quaternion.identity);
            spawnYPosition = Random.Range(nuageMin, nuageMax);
            nuages[currentNuage].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentNuage++;
            if (currentNuage >= nuagePoolSize)
            {
                currentNuage = 0;
            }
        }

    }
}
