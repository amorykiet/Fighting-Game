using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    public Animator[] heartAnimators;

    public void breakHeart(int currentHearts)
    {
        if (currentHearts < 0) return;
        heartAnimators[currentHearts - 1].SetTrigger("break");
    }

}
