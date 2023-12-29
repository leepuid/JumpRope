using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RopeAnimationCount : MonoBehaviour
{
    public RopeAnimationCount instance;

    public int count = 0;
    public TMP_Text countTxt;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
        {
            count++;
            countTxt.text = count.ToString();
        }
    }
}
