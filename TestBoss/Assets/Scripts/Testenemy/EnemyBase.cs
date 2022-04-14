using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour,IEnemyHPSender,IEnemyStateChenge
{
    [SerializeField] private int hitPoint = 100;
    [SerializeField] private int attackPoint = 100;

    // state�̊F����
    [SerializeField] private EnemyHit hit;
    [SerializeField] private EnemyAttack attack;
    [SerializeField] private EnemyChase chase;
    [SerializeField] private EnemyMove move;
    [SerializeField] private EnemyDie die;

    // ���݂�state
    private EnemyBaseState state;

    // �f�o�b�O�p�e�L�X�g
    [SerializeField] private Text debug;

    // Start is called before the first frame update
    void Start()
    {
        // HP�̎Q�ƁA�������s����C���^�[�t�F�[�X��n��
        hit.SenderSet(this);

        // state�̕ύX���s����C���^�[�t�F�[�X��n��
        attack.ChengerSet(this);
        chase.ChengerSet(this);
        move.ChengerSet(this);
        die.ChengerSet(this);
    }

    // Update is called once per frame
    void Update()
    {
        debug.text = $"state : {state}\nhitPoint : {hitPoint}";

        switch (state)
        {
            case EnemyBaseState.MOVE:
                if (DamageState()) return;
                move.Move();
                break;
            case EnemyBaseState.CHASE:
                if (DamageState()) return;
                chase.Chase();
                break;
            case EnemyBaseState.ATTACK:
                if (DamageState()) return;
                attack.Attack();
                break;
            case EnemyBaseState.DAMAGE:
                if (!hit.Bouncing) state = EnemyBaseState.MOVE;
                break;
            case EnemyBaseState.DIE:
                die.Die();
                break;
        }
    }

    // �_���[�W���󂯂邱�Ƃ��m�F����֐�
    private bool DamageState()
    {
        if (hit.Bouncing) state = EnemyBaseState.DAMAGE;
        return hit.Bouncing;
    }

    // HP��Ԃ��C���^�[�t�F�[�X�֐�
    public int HitPointSend()
    {
        return hitPoint;
    }

    // HP�����炷�C���^�[�t�F�[�X�֐�
    public void PlayerDamage(int damage)
    {
        hitPoint -= damage;
        if (hitPoint <= 0) state = EnemyBaseState.DIE;
    }

    // state��ύX����C���^�[�t�F�[�X�֐�
    public void StateChenge(EnemyBaseState state)
    {
        this.state = state;
    }
}
public enum EnemyBaseState
{
    MOVE,
    CHASE,
    ATTACK,
    ACTION,
    DAMAGE,
    DIE
}
