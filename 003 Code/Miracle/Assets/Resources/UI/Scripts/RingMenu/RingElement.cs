using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

//AssetMenu에 RingElement 생성 추가
[CreateAssetMenu(fileName = "RingElement", menuName = "RingMenu/Element", order = 2)]
//RingElement 생성
public class RingElement : ScriptableObject
{

    public string Name;                 //RingElement 이름
    public Material RingMaterial;       //RingElement에 들어갈 Mateial

}
