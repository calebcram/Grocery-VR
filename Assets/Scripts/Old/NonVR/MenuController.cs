using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
	{
        DifficultyChooseVRV2.easyDifficulty = false;
        DifficultyChooseVRV2.normalDifficulty = false;
        DifficultyChooseVRV2.hardDifficulty = false;
        SceneManager.LoadScene(sceneIndex);
	}

    public void QuitGame()
    {
        Application.Quit();
    }
}
