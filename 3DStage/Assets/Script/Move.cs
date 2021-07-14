using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move1 : MonoBehaviour
{
    public Transform goal2;//目的地オブジェクトのtransform
    private NavMeshAgent agent2;


    private void Start()
    {
    }
    private void Update()
    {

        //エージェントのNaveMeshAgentを取得する
        agent2 = GetComponent<NavMeshAgent>();
        //目的地となる座標を設定
        agent2.destination = goal2.position;
    }

}
