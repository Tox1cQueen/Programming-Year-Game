using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AImovement : MonoBehaviour
{
	// Reference to NavMeshAgent component
	NavMeshAgent navAgent;
	Vector3 destination;

	// Decision Tree control booleans 
	public bool isVisible;
	public bool isAudible;
	public bool isClose;

	// Also to the game object we will follow
	public Transform targetObject;

	Vector3 worldDeltaPosition;
	Vector2 groundDeltaPosition;
	Vector2 velocity = Vector2.zero;

	Animator Enemy;

	// Waypoints for Patrol functionality
	int nextIndex;
	public GameObject[] waypoints;

	// Sight variables
	public float fieldOfViewAngle = 360.0f;
	private SphereCollider col;

	void Start()
    {
		// Get NavAgent
		navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		navAgent.updatePosition = false;

		// Patrol Scene
		destination = NextWaypoint(Vector3.zero);

		col = GetComponent<SphereCollider>();
	}

	void Update()
    {
		// Check if target object exists
		// If so, runn Perception Tests
		if (targetObject)
		{
			// Check is the Player is Visible
			isPlayerVisible();
			// Check is the Player is Audible
			isPlayerAudible();
			// Check is the Player is Visible
			isPlayerClose();


			// Check for visibility and proximity
			if (isVisible && isClose)
			{
				// If Randomball is visible and is close, then SEEK
				seekFunction();
			}
			else if (isVisible && !isClose)
			{
				// If Randomball is visible and not close, then PATROL
				patrolFunction();
			}
			else if (!isVisible && !isAudible)
			{
				// If Randomball is not visible and not audable, then PATROL
				patrolFunction(); 
			}
			else if (!isVisible && isAudible)
			{
				// If Randomball is visible and not close, then PATROL
				patrolFunction();
			}
			else if (isClose && !isAudible)
			{
				// If Player is visible and is close, then PATROL
				patrolFunction();
			}
			else if (isVisible && isAudible)
			{
				// If Player is visible and is close, then SEEK
				seekFunction();
			}
			else if (isClose && isAudible)
			{
				// If Player is visible and is close, then SEEK
				seekFunction();
			}
		}
		else
		{
			// If RandomBall has been destroyed then Idle
			patrolFunction();
		}

		navAgent.SetDestination(destination);

		worldDeltaPosition = navAgent.nextPosition - transform.position;
		groundDeltaPosition.x = Vector3.Dot(transform.right, worldDeltaPosition);
		groundDeltaPosition.y = Vector3.Dot(transform.forward, worldDeltaPosition);

		velocity = (Time.deltaTime > 1e-5f) ? groundDeltaPosition / Time.deltaTime : velocity = Vector2.zero;
		// And we have not yet arrived at the destination....,
		bool shouldMove = velocity.magnitude > 0.025f && navAgent.remainingDistance > navAgent.radius;
		// We set the move parameter to true and set the velx and vely animator parameters. 
		//Enemy.SetBool("move", shouldMove);
		//Enemy.SetFloat("velx", velocity.x);
		//Enemy.SetFloat("vely", velocity.y);
		//Debug.Log("ShouldMove: " + shouldMove);
	}

	void OnAnimatorMove()
	{

		transform.position = navAgent.nextPosition;
	}

	void seekFunction()
	{
		// Seek out the Enemy
		destination = targetObject.position;
		// Update Canvas with current state
		
	}
	// Patrol Array of cubes (added to script)
	void patrolFunction()
	{
		// If within 2.5, then move onto next waypoint in array
		if (Vector3.Distance(transform.position, destination) < 2.5)
		{
			destination = NextWaypoint(destination);
		}
		
	}
	public Vector3 NextWaypoint(Vector3 currentPosition)
	{
		if (currentPosition != Vector3.zero)
		{
			// Find array index of given waypoint
			for (int i = 0; i < waypoints.Length; i++)
			{
				// Once found calculate next one
				if (currentPosition == waypoints[i].transform.position)
				{
					// Modulus operator helps to avoid to go out of bounds
					// And resets to 0 the index count once we reach the end of the array
					nextIndex = (i + 1) % waypoints.Length;
				}
			}
		}
		else
		{
			// Default is first index in array 
			nextIndex = 0;
		}
		return waypoints[nextIndex].transform.position;
	}

	// Checks if Player is visible using Raycast
	public void isPlayerVisible()
	{

		// Create a vector from the enemy to the player and store the angle between it and forward.
		Vector3 direction = targetObject.transform.position - transform.position;
		float angle = Vector3.Angle(direction, transform.forward);

		// Create NavMesh hit var
		NavMeshHit hit;

		// If the Ray cast hits something other than the target, then true is returned, if not false
		// So !hit is used to specify visibility and...
		// If the angle between forward and where the player is, is less than half the angle of view...
		if (!navAgent.Raycast(targetObject.transform.position, out hit) && angle < fieldOfViewAngle * 0.5f)
		{
			// ... the player is Visible
			isVisible = true;
		}
		else
		{
			// ... the player is Not Visible
			isVisible = false;
		}
	}

	// Checks if player is Audible using simple distance calculation
	public void isPlayerAudible()
	{
		// If direct distance < 20, then audible
		if (Vector3.Distance(transform.position, targetObject.position) < 20.0f)
		{
			// Is Audible
			isAudible = true;
		}
		else
		{
			// Is not Audible
			isAudible = false;

		}
	}

	// Check is Player is CloseBy based on the NavMesh
	// Distance to Player via the NavMesh is calculated here
	// If Distance < 30, then isClose == true
	public void isPlayerClose()
	{

		// Create a path and set it based on a target position.
		NavMeshPath path = new NavMeshPath();
		if (navAgent.enabled)
			navAgent.CalculatePath(targetObject.position, path);

		// Create an array of points which is the length of the number of corners in the path + 2.
		Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

		// The first point is the enemy's position.
		allWayPoints[0] = transform.position;

		// The last point is the target position.
		allWayPoints[allWayPoints.Length - 1] = targetObject.position;

		// The points inbetween are the corners of the path.
		for (int i = 0; i < path.corners.Length; i++)
		{
			allWayPoints[i + 1] = path.corners[i];
		}

		// Create a float to store the path length that is by default 0.
		float pathLength = 0;

		// Increment the path length by an amount equal to the distance between each waypoint and the next.
		for (int i = 0; i < allWayPoints.Length - 1; i++)
		{
			pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
		}

		if (pathLength < 20.0f)
		{
			// Set Close Bool true
			isClose = true;
		}
		else
		{

			// Set Close Bool false
			isClose = false;
		}
	}
}
