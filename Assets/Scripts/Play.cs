using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("working");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
