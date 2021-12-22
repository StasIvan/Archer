using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Movement))]
[DisallowMultipleComponent]
public class MovementEnemy : Movement
{
    private Transform thisTransform;
    private NavMeshAgent _agent;
    private Coroutine _moveCoroutine;
    private Vector3 _destination;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        thisTransform = transform;
        StartCoroutine(WanderRoutine());

    }
    
    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.0f, 1.5f));
            ChooseNewEndpoint();
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            yield return _moveCoroutine = StartCoroutine(MoveToGoal(thisTransform, _agent, _destination));
        }
    }

    void ChooseNewEndpoint()
    {
        _destination = new Vector3(Random.Range(thisTransform.position.x - 10, thisTransform.position.x + 10), 0, 
            Random.Range(thisTransform.position.z - 10, thisTransform.position.z + 10));
    }
}
