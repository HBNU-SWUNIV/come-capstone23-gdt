using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMGR : MonoBehaviour
{
    public void ExitButtonFunction()                    //게임종료
    {
        Application.Quit();
    }
    public void SettingButtonFunction()                 //SettingPanel열기           
    {
        GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.SetActive(true);
    }
    public void ExitSettingButtonFunction()             //SettingPanel닫기
    {
        GameObject.Find("Canvas").transform.Find("SettingPanel").gameObject.SetActive(false);
    }
    public void StartButtonFunction()                   //StartPanel열기
    {
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(true);
    }
    public void ExitStartButtonFunction()               //StartPanel닫기
    {
        GameObject.Find("Canvas").transform.Find("StartPanel").gameObject.SetActive(false);
    }
    public void SaveFileLoadButtonFunction()            //SaveFile Load하여 MainScene열기
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
    public void HomeButtonFunction()                    //HomeScene열기
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HomeScene");
    }
    public void PauseButtonFunction()                   //일시정지
    {
        Time.timeScale = 0;
        GameObject.Find("Canvas").transform.Find("PausePanel").gameObject.SetActive(true);
    }
    public void UnPauseButtonFunction()                 //일시정지해제
    {
        Time.timeScale = 1;
        GameObject.Find("Canvas").transform.Find("PausePanel").gameObject.SetActive(false);
    }

}
