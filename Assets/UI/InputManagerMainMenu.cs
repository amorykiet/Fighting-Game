using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    Animator animator;
    int sceneOption;
    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerPrefs.SetInt("LastIsWin", 3);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }       
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
        PlayerPrefs.SetInt("LastIsWin", 3);
    }

    public void StartGame()
    {
        sceneOption = 1;
        animator.SetTrigger("FadeOut");
    }

    public void Optioning()
    {

        sceneOption = 2;
        animator.SetTrigger("FadeOut");
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneOption);
    }
}
