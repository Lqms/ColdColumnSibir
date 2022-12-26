using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Player _player;

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        Rotate(_player.transform);
        RayCast();
    }

    private void Rotate(Transform target)
    {
        Vector3 lookDirection = target.position - transform.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        _sprite.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
    }

    private void FollowTarget(Transform target)
    {
        _agent.SetDestination(target.position);
    }

    private void RayCast()
    {
        Ray2D ray = new Ray2D(transform.position, _sprite.transform.right);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

        if (hit.collider != null && hit.collider.TryGetComponent(out Player player))
        {
            print("вижу игрока");
        }
        else
        {
            print("Не вижу!");
        }
    }
}
