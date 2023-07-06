using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ConditionType
{
    Buff,
    Debuff
}

[System.Serializable]
public class Condition_icon { 
    public ConditionType conditiontype;
    public string conditionname;
    public string condition_description;
    public Sprite condition_Image;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
