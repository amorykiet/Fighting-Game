using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBoss : MonoBehaviour
{
    public int level;
    public void OpenLevel()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
