using UnityEngine;
using System.Collections;

public class SetPosition : MonoBehaviour
{
    private Vector3 startPosition;

    private Vector3 destination;
    void Start()
    {
        startPosition = transform.position;
        SetDestination(transform.position);
    }

    public void CreateRandomPosition()
    {//�����_����vector2�̒l�����
        var randDestination = Random.insideUnitCircle * 8;
        SetDestination(startPosition + new Vector3(randDestination.x, 0, randDestination.y));
    }
    

    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    public Vector3 GetDestination()
    {
        return destination;
    }
    
}
