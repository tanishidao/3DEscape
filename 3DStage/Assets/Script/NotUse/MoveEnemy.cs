using UnityEngine;
using System.Collections;

public class MoveEnemy : MonoBehaviour
{
    public enum EnemyState
    {
        Walk,
        Wait,
        Chase
    };
    private CharacterController enemyController;
    private Animator animator;
    /// �ړI�n
    private Vector3 destination;
    //�����X�s�[�h
    [SerializeField]
    private float walkSpeed = 1.0f;
    //���x
    private Vector3 velocity;
    // �ړ�����
    private Vector3 direction;
    //�����t���O
    private bool arrived;
    //SetPosition�X�N���v�g
    private SetPosition setPosition;

    [SerializeField]
    private float waitTime = 5f;
    //�o�ߎ���
    private float elapsedTime;
    // �o�ߎ���
    private EnemyState state;
    //�G�̏��
    private Transform playerTransform;

    public GameObject EnemyPos;

    private Vector3 destinasion;

   
    //�v���C���[��transform
    void Start()
    {
        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        setPosition = GetComponent<SetPosition>();
        setPosition.CreateRandomPosition();
        velocity = Vector3.zero;
        arrived = false;
        elapsedTime = 0f;
        SetState(EnemyState.Walk);
        
    }
    void Update()
    {
        //�����܂��̓L�����N�^�[��ǂ��������
        if (state == EnemyState.Walk || state == EnemyState.Chase)
        {
            //�L�����N�^�[��ǂ��������Ԃł���΃L�����N�^�[�̖ړI�n���Đݒ�
            if (state == EnemyState.Chase)
            {
                setPosition.SetDestination(playerTransform.position);
            }
            if (enemyController.isGrounded)
            {
                velocity = Vector3.zero;
                animator.SetFloat("Speed", 2.0f);
                direction = (setPosition.GetDestination() - EnemyPos.transform.position).normalized;///�x�N�g����ݒ�???
                transform.LookAt(new Vector3(setPosition.GetDestination().x, EnemyPos.transform.position.y, setPosition.GetDestination().z));
               velocity = direction * walkSpeed;
            }
            //�ړI�n�ɓ����������ǂ����̔���
            if (Vector3.Distance(transform.position, setPosition.GetDestination()) < 0.5f)
            {
                SetState(EnemyState.Wait);
                animator.SetFloat("Speed", 0.0f);
            }
        }//�������Ă������莞�ԑ҂�
        else if (state == EnemyState.Wait)
        {
            elapsedTime += Time.deltaTime;
            //�҂����Ԃ��z�����玟�̖ړI�n��ݒ�
            if (elapsedTime > waitTime)
            {
                SetState(EnemyState.Walk);
            }

        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);

    }
    ///�G�L�����̏�ԕύX���\
    public void SetState(EnemyState tempState, Transform targetObj = null)
    {
        if (tempState == EnemyState.Walk)
        {
            arrived = false;
            elapsedTime = 0f;
            state = tempState;
            setPosition.CreateRandomPosition();
        }
        else if (tempState == EnemyState.Chase)
        {
            state = tempState;
            //�ҋ@��Ԃ���ǂ�������ꍇ������̂�off
            arrived = false;
            //�ǂ�������ΏۃZ�b�g
            playerTransform = targetObj;
        }
        else if (tempState == EnemyState.Wait)
        {
            elapsedTime = 0f;
            state = tempState;
            arrived = true;
            velocity = Vector3.zero;
            animator.SetFloat("Speed", 0f);

        }
    }
    public EnemyState GetState()
    {
        return state;

    }
}
