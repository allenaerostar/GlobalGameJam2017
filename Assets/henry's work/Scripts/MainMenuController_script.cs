using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController_script : MonoBehaviour {

    public GameObject airhorn;
    public AudioClip airhornSound;

    public void playAirHorn()
    {
        airhorn.GetComponent<AirHorn_script>().playHorn();
        Invoke("startGame", airhornSound.length - 1.25f);
    }

    public void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }

	public void quitGame()
    {
        Application.Quit();
    }
}
