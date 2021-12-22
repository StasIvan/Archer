using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMoveControll 
{
    IEnumerator MoveToGoal(CharacterController controller, Vector3 endPosition, float speed);
    IEnumerator MoveToGoal(Transform thisTransform, NavMeshAgent agent, Vector3 destination);
}
