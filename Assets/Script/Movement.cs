using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour, IMove, IMoveControll, IRotation
{
    public void LookAtDirection(Transform thisTransform, Vector3 direction)
    {
        thisTransform.rotation = Quaternion.LookRotation(direction);
    }

    public void Move(CharacterController character, Vector3 direction, float speed)
    {
        character.Move(direction * speed * Time.deltaTime);
    }

    public void Move(NavMeshAgent agent, Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public IEnumerator MoveToGoal(CharacterController controller, Vector3 endPosition, float speed)
    {
        Vector3 direction = endPosition - controller.transform.position;
        float _currentPosition = 0,
            _lengthDistance = direction.magnitude,
            _deltaDistance = Time.fixedDeltaTime * speed;
        while (_currentPosition <= _lengthDistance)
        {
            Move(controller, direction.normalized, speed /Time.deltaTime * Time.fixedDeltaTime);
            _currentPosition += _deltaDistance;
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator MoveToGoal(Transform thisTransform, NavMeshAgent agent, Vector3 destination)
    {
        while (thisTransform.position.x != destination.x && thisTransform.position.z != destination.z)
        {
            Move(agent, destination);
            yield return new WaitForFixedUpdate();
        }
        
    }

    /*public void Move(Rigidbody rb, Vector3 direction, float speed)
    {
        rb.AddForce(direction * speed * Time.fixedDeltaTime);
    }

    public void Move(Transform transform, Vector3 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }*/
}
