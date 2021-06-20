using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    private void Start()
    {
        PlayerTransform = transform.parent;
        CameraTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        PlayerTransform.transform.Rotate(0, x_Rotation, 0);
        CameraTransform.transform.Rotate(-y_Rotation, 0, 0);

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));
        if(Input.GetKey(KeyCode.W))
        {
            PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A))
        {
            PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
        }

    }
}
