using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMGR : MonoBehaviour
{
    //RingMenu
    public RingMenu MainMenuPrefab;
    protected RingMenu MainMenuInstance;

    [HideInInspector]
    public ControllerMode Mode;
    // Start is called before the first frame update
    void Start()
    {
        SetMode(ControllerMode.Play);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mode == ControllerMode.Play)
        {
            if (Input.GetMouseButtonDown(1))
            {
                SetMode(ControllerMode.ColorSelect);
                MainMenuInstance = Instantiate(MainMenuPrefab, FindAnyObjectByType<Canvas>().transform);
            }
        }
    }
    public void SetMode(ControllerMode mode)
    {
        Mode = mode;

        switch (mode)
        {
            case ControllerMode.Pause:
                Time.timeScale = 0;
                Debug.Log("Pause");
                break;
            case ControllerMode.ColorSelect:
                Time.timeScale = 0.5f;
                Debug.Log("ColorSelect");
                break;
            case ControllerMode.Play:
                Time.timeScale = 1;
                Debug.Log("Play");
                break;
        }
    }

    public enum ControllerMode
    {
        Play,                   //게임플레이
        ColorSelect,            //색 선택
        Pause                   //일시정지
    }
}
