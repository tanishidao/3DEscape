using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeEye : MonoBehaviour
{
    public Text timetext;
    void Start()
    {
        timetext.text = "あなたは" + TimeManager.Instance.time + "秒でクリア";
    }

}
