using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;



public class ItemScript3 : MonoBehaviour
{
    [SerializeField] float turnSpeed = 3f; // アイテムを回転させる速さ
    [SerializeField] GameObject item; // アイテム
    [SerializeField] GameObject image; // 手のマーク
    [SerializeField] float d = 1f; // 持ったアイテムのカメラからの距離
    [SerializeField] float armLength = 2f; // レイの長さ
    [SerializeField] Text text;
    [SerializeField] PhysicMaterial itemPM_hold; // 持った時のアイテムの物理マテリアル

    RaycastHit hit;
    Vector3 itemPos; // アイテムのデフォルトの位置
    Quaternion itemRot; // アイテムのデフォルトの回転
    bool hold = false; // アイテムを持ち上げているかどうか
    int state = 0;
    UnityStandardAssets.Characters.FirstPerson.FirstPersonController sc_camera;
    Rigidbody itemRb;
    float itemDist = 0f;
    Collider itemColl;
    PhysicMaterial itemPM; // アイテムの元の物理マテリアル




    // Start is called before the first frame update
    void Start()
    {
        sc_camera = transform.parent.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }
    // Update is called once per frame
    void Update()
    {
        
         if (state == 0)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, armLength, ~(1 << 10)))
            {
                if (hit.collider.tag == "Item")
                {
                    image.SetActive(true); // 手のマークを出す


                    // アイテムを持って移動

                    if (CrossPlatformInputManager.GetButtonDown("Fire1"))
                    {
                        itemColl = hit.collider;
                        // アイテムの物理マテリアルを変更
                        itemPM = itemColl.material;
                        itemColl.material = itemPM_hold;
                        item = itemColl.gameObject;
                        itemRb = item.GetComponent<Rigidbody>();
                        itemRb.useGravity = false;
                        itemRot = item.transform.rotation;
                        itemPos = transform.InverseTransformPoint(item.transform.position);
                        itemDist = itemPos.magnitude;
                        state = 2;
                    }
                }
                else
                {
                    image.SetActive(false);
                }
            }

        
        else
        {
            image.SetActive(false);
        }
        }
        // アイテムを移動させる
        else if (state == 2)
        {
            itemRb.velocity = (transform.forward * itemDist + transform.position - item.transform.position) * 10f;
            itemRb.angularVelocity = transform.up * Vector3.Dot(item.transform.forward, transform.forward) * turnSpeed;
            //itemRb.angularVelocity = Vector3.Cross(item.transform.forward, transform.forward) * Vector3.Dot(item.transform.forward, transform.forward) * turnSpeed;
            if (CrossPlatformInputManager.GetButtonUp("Fire1"))
            {
                // アイテムの物理マテリアルをもとに戻す
                itemColl.material = itemPM;
                itemRb.useGravity = true;
                itemRb.isKinematic = false;
                state = 0;
            }
        }
    }
}