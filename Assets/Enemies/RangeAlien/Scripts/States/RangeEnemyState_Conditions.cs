using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemyState_Conditions
{
    // Start is called before the first frame update

    private GameObject _player;
    private NavMeshAgent _navMeshAgent;
    private RangeEnemyReferences _enemy;

    private float _maxChaseDistance = 50f; // Si te alejas mas de esto pasa a idle

    private float _maxAttackDistance = 20f; // Si te alejas mas de esto pasa a chase

    public RangeEnemyState_Conditions(RangeEnemyReferences enemy) {
        _player = GameObject.FindWithTag("Player");
        _navMeshAgent = enemy.navMeshAgent;
        _enemy = enemy;
    }

    public bool playerInAttackRange() {
        if (Vector3.Distance(_navMeshAgent.transform.position, _player.transform.position) <= _maxAttackDistance) 
            return true;
        return false;
    }

    public bool playerInChaseRange() {
        float distance = Vector3.Distance(_navMeshAgent.transform.position, _player.transform.position);
        if (distance > _maxAttackDistance && distance < _maxChaseDistance) 
            return true;
        return false;
    }

    public bool playerTooFar() {
        float distance = Vector3.Distance(_navMeshAgent.transform.position, _player.transform.position);

        if (distance >= _maxChaseDistance) 
            return true;
        return false;
    }
    
}
