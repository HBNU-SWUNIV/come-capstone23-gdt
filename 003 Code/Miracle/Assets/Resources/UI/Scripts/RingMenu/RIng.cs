using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//AssetMenu에 Ring 생성 추가
[CreateAssetMenu(fileName = "Ring", menuName = "RingMenu/Ring", order = 1)]
//Ring 생성
public class Ring : ScriptableObject
{
    public RingElement[] Elements;

}

