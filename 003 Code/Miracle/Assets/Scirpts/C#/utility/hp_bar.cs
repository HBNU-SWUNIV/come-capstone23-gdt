using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_bar : MonoBehaviour
{
    Player_Status player_Status = new Player_Status();
    public Image bar;

    void Start()
    {
        
    }

    void Update()
    {
        bar.fillAmount = player_Status.current_hp / player_Status.max_hp;
    }
}
