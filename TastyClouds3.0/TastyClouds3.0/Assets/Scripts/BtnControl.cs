using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnControl : MonoBehaviour {

	public void NewGameBtn(string SceneACharger)
    {
        SceneManager.LoadScene(SceneACharger);
    }

}
