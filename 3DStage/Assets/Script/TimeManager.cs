using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    public readonly static TimeManager Instance = new TimeManager();
    public Text text;
    public  float time = 0f;
    void Start()
    {

        Instance.time = 0f;
        Debug.Log("���Z�b�g�Ȃ�");
    }

    // Update is called once per frame
    void Update()
    {
        Instance.time += Time.deltaTime;
       // Debug.Log("�o�ߎ���" + Instance.time);
        text.text = string.Format("�o�ߎ���" + Instance.time + "�b");
    }
}
