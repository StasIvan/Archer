using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Movement))]
[DisallowMultipleComponent]
public class MovementEnemy : MonoBehaviour
{
    Transform _thisTransform;
    NavMeshAgent _agent;
    Coroutine _moveCoroutine;
    [SerializeField] Vector3 _destination;
    Movement _movement;
    
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _movement = GetComponent<Movement>();
        _thisTransform = transform;
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
            yield return _moveCoroutine = StartCoroutine(_movement.MoveToGoal(_thisTransform, _agent, _destination));
        }
    }

    void ChooseNewEndpoint()
    {
        _destination = new Vector3(Random.Range(_thisTransform.position.x - 10, _thisTransform.position.x + 10), 0, 
            Random.Range(_thisTransform.position.z - 10, _thisTransform.position.z + 10));
    }
}
