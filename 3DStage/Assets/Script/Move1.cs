using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    public Transform goal;//�ړI�n�I�u�W�F�N�g��transform
    private NavMeshAgent agent;
    

    private void Start()
    {
        //�G�[�W�F���g��NaveMeshAgent���擾����
        agent = GetComponent<NavMeshAgent>();
        //�ړI�n�ƂȂ���W��ݒ�
        agent.destination = goal.position;
    }
}
