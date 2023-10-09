using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIMGR : MonoBehaviour
{
    public void StartBTNFunction()
    {
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(true);
    }

    public void StartYesBTNFunction()
    {
        SceneManager.LoadScene("Village");
    }

    public void StartNoBTNFunction()
    {
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(false);
    }

    public void LoadBTNFunction()
    {
        GameObject.Find("Canvas").transform.Find("LoadPanel").gameObject.SetActive(true);
    }

    public void LoadExitBTNFunction()
    {
        GameObject.Find("Canvas").transform.Find("LoadPanel").gameObject.SetActive(false);
    }

    public void SettingBTNFunction()
    {

    }

    public void ExitBTNFunction()
    {
        Application.Quit();
    }
}
