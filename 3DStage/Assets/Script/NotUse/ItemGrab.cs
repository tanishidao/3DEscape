using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class ItemGrab : MonoBehaviour
{
    [SerializeField] float turnSpeed = 3f;
    [SerializeField] GameObject item;
    [SerializeField] GameObject image;
    [SerializeField] float d = 1f;
    [SerializeField] float armLength = 2f;
    [SerializeField] Text text;
    [SerializeField] PhysicMaterial itemPM_holdl;

    RaycastHit hit;
    Vector3 itemPos;
    Quaternion itemRot;
    bool hold = false;
    int state = 0;
    UnityStandardAssets.Characters.FirstPerson.FirstPersonController sc_camera;
    Rigidbody itemRb;
        float itemDist = 0f;
    Collider itemColl;
    PhysicMaterial itemPM;
     void Start()
    {
       /// sc_camera = transform.parent.GetComponent();
    }
    private void Update()
    {
        if (state == 1)
        {
            //ドラッグでアイテムを確認
            if (CrossPlatformInputManager.GetButton("Fire1"))
            {
                var x = CrossPlatformInputManager.GetAxis("Mouse X");
                var y = CrossPlatformInputManager.GetAxis("Mouse Y");
                //シフトを押しているとき
                if (CrossPlatformInputManager.GetButton("Fire3"))
                {
                    d += y / 5f;
                    d = Mathf.Clamp(d, 0.5f, 4f);
                    item.transform.position = transform.position + transform.forward * d;
                }
                //押してないとき
                else
                {
                    item.transform.localRotation *= Quaternion.Euler(item.transform.InverseTransformDirection(transform.up) * x * -turnSpeed);
                    item.transform.localRotation *= Quaternion.Euler(item.transform.InverseTransformDirection(transform.up) * y * turnSpeed);
                }
            } 
            //Eでアイテムをおく
            if(Input.GetKeyDown(KeyCode.E))
            {
                item.transform.position = itemPos;
                item.transform.rotation = itemRot;

                itemRb.useGravity = true;
                itemRb.isKinematic = false;
                //hold = false:

                state = 0;
                ///sc_camera.LockCamera(false);
            }

        }
    }

}
