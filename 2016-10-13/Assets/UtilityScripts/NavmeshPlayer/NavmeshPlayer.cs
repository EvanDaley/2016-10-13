using UnityEngine;
using System.Collections;

public class NavmeshPlayer : MonoBehaviour {

	public int previousWaypoint;
	public NavMeshAgent agent;
	private int movementStatus = 0;

	void Start()
	{
		agent.updateRotation = false;
	}

	public void SetCycle(int status)
	{
		
		movementStatus = status;
		UpdatePath ();
	}

	void UpdatePath()
	{
		if (movementStatus == 0)
		{
			agent.SetDestination (transform.position);
		}
		else if (movementStatus == 1)
		{
			Waypoint nextPos = WaypointManager.Instance.FindNextWaypointForward (previousWaypoint);
			if(nextPos != null)
				agent.SetDestination (nextPos.transform.position);
		}
		else if (movementStatus == 2)
		{
			Waypoint nextPos = WaypointManager.Instance.FindNextWaypointBackward (previousWaypoint);
			if(nextPos != null)
				agent.SetDestination (nextPos.transform.position);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 10)
		{
			print ("Hit waypoitn");

			Waypoint waypoint = other.GetComponent<Waypoint> ();
			if (waypoint != null)
				previousWaypoint = waypoint.value;
			
			UpdatePath ();
		}
	}
}

