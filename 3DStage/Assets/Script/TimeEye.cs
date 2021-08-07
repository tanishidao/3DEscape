using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeEye : MonoBehaviour
{
    public Text timetext;
    void Start()
    {
        timetext.text = "‚ ‚È‚½‚Í" + TimeManager.Instance.time + "•b‚ÅƒNƒŠƒA";
    }

}
