using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public GameManager instance;

    public GameObject endPanel;
    public List<Image> life;
    public Animator _animator;


    public float ropeSpeed = 0.01f;

    private bool isGameOver = false; 
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(_animator != null)
        {
            _animator.speed += ropeSpeed * Time.deltaTime;
        }

        if(isGameOver)
        {
            Time.timeScale = 0f;
        }
    }

    public void DecreaseLife()
    {
        Image lifeRemove = life[life.Count - 1];
        lifeRemove.gameObject.SetActive(false);
        life.RemoveAt(life.Count - 1);

        gameOver();
    }

    private void gameOver()
    {
        if(!isGameOver && life.Count <= 0)
        {
            endPanel.SetActive(true);
            isGameOver = true;
        }
    }

}
