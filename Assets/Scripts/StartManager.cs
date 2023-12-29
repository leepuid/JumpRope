using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void PlayerBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameEnd()
    {
        Application.Quit();
    }
}
