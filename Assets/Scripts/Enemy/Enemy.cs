using UnityEngine;

public class Enemy : MonoBehaviour, IMovable
{
    [Header("Positions")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float speed = 2f;
    private int currentPointIndex = 0;
    private void Update()
    {
        Transform targetPoint = patrolPoints[currentPointIndex];

        Vector3 direction = (targetPoint.position - transform.position).normalized;

        Move(direction * speed * Time.deltaTime);

        currentPointIndex++;

        if (currentPointIndex >= patrolPoints.Length)
        {
            currentPointIndex = 0;
        }
    }
    public void Move(Vector3 direction)
    {
        transform.position += direction;
    }
}
