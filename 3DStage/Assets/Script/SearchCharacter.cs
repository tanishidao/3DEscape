using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    private MoveEnemy moveEnemy;
    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
    }

    private void OnTriggerStay(Collider col)
    {
        //�v���C���[�L�����N�^�[�𔭌�
        if(col.tag == "Player")
        {
            //�G�L�����N�^�[�̏�Ԃ��擾
            MoveEnemy.EnemyState state = moveEnemy.GetState();
           //�G�L�����N�^�[���ǂ��������ԂłȂ���Βǂ�������
            if (state != MoveEnemy.EnemyState.Chase)
            {
                Debug.Log("player����");
                moveEnemy.SetState(MoveEnemy.EnemyState.Chase, col.transform);
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            Debug.Log("������");
            moveEnemy.SetState(MoveEnemy.EnemyState.Wait);
        }
    }
}
        
