using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{

    public enum EnemyState
    {
        PATROL,
        CHASE,
        ATTACK
    }

    [SerializeField] private EnemyState _currentState = EnemyState.PATROL;

    public IEnumerator AIPatrol()
    {
        yield break;
    }
    public IEnumerator AIChase()
    {
        yield break;
    }
    public IEnumerator AIAttack()
    {
        yield break;
    }
}
