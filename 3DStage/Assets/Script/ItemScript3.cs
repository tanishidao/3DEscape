using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;



public class ItemScript3 : MonoBehaviour
{
    [SerializeField] float turnSpeed = 3f; // �A�C�e������]�����鑬��
    [SerializeField] GameObject item; // �A�C�e��
    [SerializeField] GameObject image; // ��̃}�[�N
    [SerializeField] float d = 1f; // �������A�C�e���̃J��������̋���
    [SerializeField] float armLength = 2f; // ���C�̒���
    [SerializeField] Text text;
    [SerializeField] PhysicMaterial itemPM_hold; // ���������̃A�C�e���̕����}�e���A��

    RaycastHit hit;
    Vector3 itemPos; // �A�C�e���̃f�t�H���g�̈ʒu
    Quaternion itemRot; // �A�C�e���̃f�t�H���g�̉�]
    bool hold = false; // �A�C�e���������グ�Ă��邩�ǂ���
    int state = 0;
    UnityStandardAssets.Characters.FirstPerson.FirstPersonController sc_camera;
    Rigidbody itemRb;
    float itemDist = 0f;
    Collider itemColl;
    PhysicMaterial itemPM; // �A�C�e���̌��̕����}�e���A��




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
                    image.SetActive(true); // ��̃}�[�N���o��


                    // �A�C�e���������Ĉړ�

                    if (CrossPlatformInputManager.GetButtonDown("Fire1"))
                    {
                        itemColl = hit.collider;
                        // �A�C�e���̕����}�e���A����ύX
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
        // �A�C�e�����ړ�������
        else if (state == 2)
        {
            itemRb.velocity = (transform.forward * itemDist + transform.position - item.transform.position) * 10f;
            itemRb.angularVelocity = transform.up * Vector3.Dot(item.transform.forward, transform.forward) * turnSpeed;
            //itemRb.angularVelocity = Vector3.Cross(item.transform.forward, transform.forward) * Vector3.Dot(item.transform.forward, transform.forward) * turnSpeed;
            if (CrossPlatformInputManager.GetButtonUp("Fire1"))
            {
                // �A�C�e���̕����}�e���A�������Ƃɖ߂�
                itemColl.material = itemPM;
                itemRb.useGravity = true;
                itemRb.isKinematic = false;
                state = 0;
            }
        }
    }
}