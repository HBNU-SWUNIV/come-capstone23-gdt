using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//AssetMenu俊 Ring 积己 眠啊
[CreateAssetMenu(fileName = "Ring", menuName = "RingMenu/Ring", order = 1)]
//Ring 积己
public class Ring : ScriptableObject
{
    public RingElement[] Elements;

}

