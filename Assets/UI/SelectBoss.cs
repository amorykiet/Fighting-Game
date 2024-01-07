using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectBoss : MonoBehaviour
{
    public Button[] levelButtons;

    private void Awake()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }

        for (int i = 0;i < unlockedLevels; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    public void OpenLevel(int level)
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
