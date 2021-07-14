using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    public Transform goal;//目的地オブジェクトのtransform
    private NavMeshAgent agent;
    

    private void Start()
    {
        //エージェントのNaveMeshAgentを取得する
        agent = GetComponent<NavMeshAgent>();
        //目的地となる座標を設定
        agent.destination = goal.position;
    }
}
