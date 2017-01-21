using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController_script : MonoBehaviour {

    public void startGame()
    {
        SceneManager.LoadScene("scene_henry");
    }

	public void quitGame()
    {
        Application.Quit();
    }
}
