using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private List<GameObject> menus;
    [SerializeField] private AudioClip click;
    private AudioSource source;

    private void Start() {
        source = GetComponent<AudioSource>();
    }

    public void OpenMenu(string name) {
        source.PlayOneShot(click);

        foreach (GameObject g in menus) {
            if (g.name == name) {
                g.SetActive(true);
            } else {
                g.SetActive(false);
            }
        }
    }

    public void StartGame_Easy() {
        //Set difficulty to Easy
        source.PlayOneShot(click);
        DifficultyChooseVRV2.easyDifficulty = true;
        SceneManager.LoadScene(1);
    }

    public void StartGame_Medium() {
        //Set difficulty to Medium
        source.PlayOneShot(click);
        DifficultyChooseVRV2.normalDifficulty = true;
        SceneManager.LoadScene(1);
    }
    public void StartGame_Hard() {
        //Set difficulty to Hard
        source.PlayOneShot(click);
        DifficultyChooseVRV2.hardDifficulty = true;
        SceneManager.LoadScene(1);
    }
}
