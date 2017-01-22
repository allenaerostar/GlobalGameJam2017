using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController_script : MonoBehaviour {

    public void startGame()
    {
        //change "scene_henry" to the name of the main scene.
        SceneManager.LoadScene("GameScene");
    }

	public void quitGame()
    {
        Application.Quit();
    }
}
