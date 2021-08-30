using UnityEngine;
using UnityEngine.AI;

public interface IMove
{
    void Move(CharacterController character, Vector3 direction, float speed);
    void Move(NavMeshAgent agent, Vector3 destination);
    //void Move(Rigidbody rb, Vector3 direction, float speed);
    //void Move(Transform transform, Vector3 direction, float speed);
}