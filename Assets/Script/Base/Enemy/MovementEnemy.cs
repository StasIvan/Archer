using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class MovementEnemy : Movement
{
    [HideInInspector] public Transform thisTransform;

    private NavMeshAgent _agent;
    private Coroutine _moveCoroutine;
    private Vector3 _destination;
    
    private void Start()
    {
        Init();
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

    private void ChooseNewEndpoint()
    {
        _destination = new Vector3(Random.Range(thisTransform.position.x - 10, thisTransform.position.x + 10), 0, 
            Random.Range(thisTransform.position.z - 10, thisTransform.position.z + 10));
    }

    private void Init()
    {
        _agent = GetComponent<NavMeshAgent>();
        thisTransform = transform;
        StartCoroutine(WanderRoutine());
        SetPreviousPos(thisTransform);
    }

}
