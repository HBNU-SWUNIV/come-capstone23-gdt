using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMGR : MonoBehaviour
{
    public void ExitButtonFunction()                    //��������
    {
        Application.Quit();
    }
    public void SettingButtonFunction()                 //SettingPanel����           
    {
        GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.SetActive(true);
    }
    public void ExitSettingButtonFunction()             //SettingPanel�ݱ�
    {
        GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.SetActive(false);
    }
    public void StartButtonFunction()                   //StartPanel����
    {
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(true);
    }
    public void ExitStartButtonFunction()               //StartPanel�ݱ�
    {
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(false);
    }
    public void SaveFileLoadButtonFunction()            //SaveFile Load�Ͽ� MainScene����
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
    public void HomeButtonFunction()                    //HomeScene����
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HomeScene");
    }
    public void PauseButtonFunction()                   //�Ͻ�����
    {
        Time.timeScale = 0;
        GameObject.Find("Canvas").transform.Find("PausePanel").gameObject.SetActive(true);
    }
    public void UnPauseButtonFunction()                 //�Ͻ���������
    {
        Time.timeScale = 1;
        GameObject.Find("Canvas").transform.Find("PausePanel").gameObject.SetActive(false);
    }

}
