using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;
    /// 目的地
    private Vector3 destination;
    //歩くスピード
    [SerializeField]
    private float walkSpeed = 1.0f;
    //速度
    private Vector3 velocity;
    // 移動方向
    private Vector3 direction;
    //到着フラグ
    private bool arrived;
    //SetPositionスクリプト
    private SetPosition setPosition;

    [SerializeField]
    private float waitTime = 5f;
    //経過時間
    private float elapsedTime;
    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
     
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;

    }
    void Update()
    {
        if (!arrived)
        {
            if (enemyController.isGrounded)
            {
                velocity = Vector3.zero;
                animator.SetFloat("Speed", 2.0f);
                direction = (destination - transform.position).normalized;
                transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
                velocity = direction * walkSpeed;
                Debug.Log(destination);

            }
            velocity.y += Physics.gravity.y * Time.deltaTime;
            enemyController.Move(velocity * Time.deltaTime);

            //目的地に到着したかどうかの判定
            if (Vector3.Distance(transform.position, destination) < 0.5f)
            {
                arrived = true;
                animator.SetFloat("Speed", 0.0f);
                Debug.Log("ついた！");
            }
           //到着したら
            else
            {
                elapsedTime += Time.deltaTime;
                Debug.Log("時間獲得");
                //　待ち時間を越えたら次の目的地を設定
                if (elapsedTime > waitTime)
                {
                    setPosition.CreateRandomPosition();
                    destination = setPosition.GetDestination();
                    arrived = false;
                    elapsedTime = 0f;
                    Debug.Log("目的地変更");
                }
               
            }
            Debug.Log(elapsedTime);

        }
    }
}
