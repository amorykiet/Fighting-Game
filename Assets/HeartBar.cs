using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    public Animator[] heartAnimators;

    public void breakHeart(int currentHearts)
    {
        //Debug.Log(heartAnimators.Length);
        heartAnimators[currentHearts - 1].SetTrigger("break");
    }

}
