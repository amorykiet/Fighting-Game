using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManagerBoss : MonoBehaviour
{
    public Button[] levelButtons;
    public Animator animator;
    int selectedLevel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }


    private void Awake()
    {
        if (PlayerPrefs.GetInt("LastIsWin", 1) == 0)
        {
            animator.SetTrigger("Win Fade In");
        }
        else
        { 
            animator.SetTrigger("Fade In");
        }
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevels; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    public void SelectLevel(int level)
    {
        selectedLevel = level;
        animator.SetTrigger("Fade Out");
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene("Level " + selectedLevel.ToString());
    }
}
