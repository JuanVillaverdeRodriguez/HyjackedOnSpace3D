using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyState_Idle : IState
{
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    public RangeEnemyState_Idle(NavMeshAgent navMeshAgent, Animator animator)
    {
        _navMeshAgent = navMeshAgent;
        _animator = animator;
    }

    public void OnEnter()
    {
        _animator.SetBool("idle", true);

    }

    public void OnExit()
    {
        _animator.SetBool("idle", false);
    }

    public void Tick()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
