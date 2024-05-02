using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(RangeEnemyReferences))]
[DisallowMultipleComponent]
public class RangeEnemyState_Controller : MonoBehaviour
{   
    private StateMachine _stateMachine;

    void Start()
    {
        // Maquina de estados
        _stateMachine = new StateMachine();
        
        // Referencias a otros scripts y componentes
        RangeEnemyReferences enemy = GetComponent<RangeEnemyReferences>();
        
        // Condiciones para el cambio de estado
        RangeEnemyState_Conditions conditions = new RangeEnemyState_Conditions(enemy);

        //Estados
        var chase = new RangeEnemyState_Chase(enemy.navMeshAgent, enemy.animator);
        var shoot = new RangeEnemyState_Shoot(enemy.navMeshAgent, enemy.animator, enemy.enemyShootController);
        var idle = new RangeEnemyState_Idle(enemy.navMeshAgent, enemy.animator);

        //Transiciones
        At(chase, shoot, conditions.playerInAttackRange);
        At(chase, idle, conditions.playerTooFar);
        Any(chase, conditions.playerInChaseRange);
        
        //Estado inicial
        _stateMachine.SetState(chase);

        //Funciones y condiciones
        void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition); // Desde un estado concreto a otro
        void Any(IState to, Func<bool> condition) => _stateMachine.AddAnyTransition(to, condition); // Desde cualquier estado a otro
        
    }

    void Update()
    {
        // Actualiza la maquina de estados
        _stateMachine.Tick();
    }

}
