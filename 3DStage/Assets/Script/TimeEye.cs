using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeEye : MonoBehaviour
{
    public Text timetext;
    void Start()
    {
        timetext.text = "���Ȃ���" + TimeManager.Instance.time + "�b�ŃN���A";
    }

}
