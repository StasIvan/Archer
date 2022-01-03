using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour, IMove, IMoveControll, IRotation
{
    protected Vector3 _previousPos;
    

    public bool IsObjectMove(Transform currentTrans)
    {
        bool isMove = _previousPos != currentTrans.position;
        SetPreviousPos(currentTrans);
        return isMove;
    }

    public void LookAtDirection(Transform thisTransform, Vector3 direction)
    {
        thisTransform.rotation = Quaternion.LookRotation(direction);
    }

    public void Move(CharacterController character, Vector3 direction, float speed)
    {
        character.Move(direction * speed * Time.deltaTime);
    }

    public void Move(Transform character, Vector3 direction, float speed)
    {
        character.Translate(direction * speed * Time.deltaTime, Space.World);
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

    protected void SetPreviousPos(Transform transform)
    {
        _previousPos = transform.position;
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
