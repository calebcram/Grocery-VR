using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{   
    public void StartGame_Easy()
    {
        //Set difficulty to Easy
        DifficultyChooseVRV2.easyDifficulty = true;
        SceneManager.LoadScene(1);
    }

    public void StartGame_Medium()
    {
        //Set difficulty to Medium
        DifficultyChooseVRV2.normalDifficulty = true;
        SceneManager.LoadScene(1);
    }
    public void StartGame_Hard()
    {
        //Set difficulty to Hard
        DifficultyChooseVRV2.hardDifficulty = true;
        SceneManager.LoadScene(1);
    }
}