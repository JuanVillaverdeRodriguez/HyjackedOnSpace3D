using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyState_Chase : IState
{

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private GameObject _player;
    private float _updateTargetingDelay = 0.2f;

    public RangeEnemyState_Chase(NavMeshAgent navMeshAgent, Animator animator) {
        _navMeshAgent = navMeshAgent;
        _animator = animator;
        _player = GameObject.FindWithTag("Player");
    }

    public void OnEnter()
    {
        _animator.SetBool("run", true);
        _navMeshAgent.isStopped = false;

    }

    public void OnExit()
    {
        _animator.SetBool("run", false);
        _navMeshAgent.isStopped = true;
    }
    

    public void Tick()
    {
        _updateTargetingDelay -= Time.deltaTime;
        if (_updateTargetingDelay <= 0 && !_navMeshAgent.isStopped) {
            _updateTargetingDelay = 0.2f;
            
            _navMeshAgent.SetDestination(_player.transform.position);
        }

    }
    
}
