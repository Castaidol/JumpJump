using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseChar : MonoBehaviour {
    
    public void ChooseReed()
    {
        PlayerPrefs.SetInt("Character", 0);
    }

    public void ChooseGreen()
    {
        PlayerPrefs.SetInt("Character", 1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

	
}
