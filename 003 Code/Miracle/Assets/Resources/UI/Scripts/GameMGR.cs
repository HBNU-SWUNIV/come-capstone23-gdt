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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
                MainMenuInstance = Instantiate(MainMenuPrefab, FindAnyObjectByType<Canvas>().transform);
        }
    }
}
