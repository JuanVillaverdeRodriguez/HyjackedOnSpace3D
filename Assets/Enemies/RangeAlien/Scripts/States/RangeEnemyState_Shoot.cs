using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyState_Shoot : IState
{

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private GameObject _player;
    private EnemyShootController _enemyShoot;
    public float _shootingCooldown = 0.5f;

    public RangeEnemyState_Shoot(NavMeshAgent navMeshAgent, Animator animator, EnemyShootController enemyShoot) {
        _navMeshAgent = navMeshAgent;
        _animator = animator;
        _enemyShoot = enemyShoot;
        _player = GameObject.FindWithTag("Player");

    }

    public void OnEnter()
    {
        _animator.SetBool("shoot", true);
        _shootingCooldown = 1f;
    }

    public void OnExit()
    {
        _animator.SetBool("shoot", false);
    }
    public void Tick()
    {
        _navMeshAgent.transform.LookAt(new Vector3(_player.transform.position.x, _navMeshAgent.transform.position.y, _player.transform.transform.position.z));
        
        _shootingCooldown -= Time.deltaTime;
        if (_shootingCooldown <= 0) {
            _shootingCooldown = 0.5f;
            _enemyShoot.shoot(_player.transform.position);

        }

    }

    
}
