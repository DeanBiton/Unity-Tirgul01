using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start(){}

    void Update(){}

    public void playBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void howBtn()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void exitBtn()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void CancelBtn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void X()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
