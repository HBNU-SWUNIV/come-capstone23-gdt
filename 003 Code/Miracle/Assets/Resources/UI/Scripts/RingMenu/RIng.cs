using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Ring", menuName = "RingMenu/Ring", order = 1)]
//Ring ����
public class Ring : ScriptableObject
{
    public RingElement[] Elements;

}

