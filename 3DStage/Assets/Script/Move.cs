using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move1 : MonoBehaviour
{
    public Transform goal2;//�ړI�n�I�u�W�F�N�g��transform
    private NavMeshAgent agent2;


    private void Start()
    {
    }
    private void Update()
    {

        //�G�[�W�F���g��NaveMeshAgent���擾����
        agent2 = GetComponent<NavMeshAgent>();
        //�ړI�n�ƂȂ���W��ݒ�
        agent2.destination = goal2.position;
    }

}
