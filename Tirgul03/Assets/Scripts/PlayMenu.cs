using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    void Start(){}

    void Update(){}

    public void goBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
