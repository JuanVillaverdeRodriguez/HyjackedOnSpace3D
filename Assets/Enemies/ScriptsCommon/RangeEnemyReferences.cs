using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Guarda referencias a otros objetos y scripts
// Permite que con solo referenciar este script, se pueda acceder a las demas referencias facilmente
[RequireComponent(typeof(EnemyShootController))]
[RequireComponent(typeof(HealthController))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[DisallowMultipleComponent]
public class RangeEnemyReferences : MonoBehaviour
{
    [HideInInspector] public EnemyShootController enemyShootController;
    [HideInInspector] public HealthController healthController;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Animator animator;
    public bool canMove = true;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyShootController = GetComponent<EnemyShootController>();

    }
}
