using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] positions;
    private int currentPosition;
    private bool isDetected=false;
    private Transform player;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!isDetected)
        {
            if (agent.remainingDistance <= 0.3f)
            {
                GoToNextPoint();
            }
        }
        else
        {
            Destination(player.position);
        }
    }
    private void GoToNextPoint()
    {
        currentPosition = (currentPosition + 1) % positions.Length;
        Destination(positions[currentPosition].position);
    }

    private void Destination(Vector3 newPosition)
    {
        agent.SetDestination(newPosition);
    }
    private void OnDrawGizmos()
    {
        if(positions!=null)
        {
            Gizmos.color = Color.green;

            for (int i = 0; i < positions.Length; i++)
            {
                Gizmos.DrawSphere(positions[i].position, 0.3f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            isDetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            isDetected = false;
        }
    }
}
