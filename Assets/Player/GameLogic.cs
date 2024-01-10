using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    Animator FadeEffect;
    bool ending;
    int maxLevels = 5;
    GameObject[] Boss;

    private void Awake()
    {
        FadeEffect = GetComponent<Animator>();
    }

    private void Start()
    {
        Boss = GameObject.FindGameObjectsWithTag("Enemy");
        ending = false;
    }

    public void Win()
    {
        PlayerPrefs.SetInt("LastIsWin", 0);
        FadeEffect.SetTrigger("Win");
        UnlockNewLevel();
    }

    public void Lose()
    {
        PlayerPrefs.SetInt("LastIsWin", 1);
        FadeEffect.SetTrigger("Lose");
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex") && PlayerPrefs.GetInt("UnlockedLevels", 1) < maxLevels) 
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevels", PlayerPrefs.GetInt("UnlockedLevels", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    public void BackToBossMenu()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        foreach (GameObject boss in Boss)
        {
            if (!boss.GetComponent<Boss_Health>().dead)
            {
                return;
            }
        }
        //If all boss dead
        if (!ending && Boss.Length > 0)
        {
            Win();
            ending = true;
        }
    }
}
