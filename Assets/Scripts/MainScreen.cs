using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour {

	public void LaunchGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
