using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public void Win()
    {
        Debug.Log("VICTORY");
        SceneManager.LoadScene(1);
    }

    public void Lose()
    {
        Debug.Log("DEFEAT");
        SceneManager.LoadScene(1);
    }
}
