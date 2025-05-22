using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit hit;
            ray = cam.ScreenPointToRay (Input.mousePosition);

            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                agent.SetDestination(hit.point); 
            }
        }
    }
}
