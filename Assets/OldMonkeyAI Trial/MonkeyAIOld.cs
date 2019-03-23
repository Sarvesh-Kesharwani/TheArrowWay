using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class MonkeyAI : MonoBehaviour
{
    public Transform target;
    public float updateRate = 2f;

    private Seeker Seeker;
    private Rigidbody2D rigidbody2D;

    public Path path;

    public float speed = 300;
    public ForceMode2D fMode;

    [HideInInspector] public bool pathIsEnded = false;

    public float nextWayPointDistance = 3;

    private int currentWaypoint = 0;

    void Start()
    {
        Seeker = GetComponent<Seeker>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.LogError("No Player found? PANIC!");
            return;
        }

        Seeker.StartPath(transform.position, target.position, OnPathComplete);
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            yield return false;
        }

        Seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("We god a path. Did it have an error?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            Debug.Log("End Of path reached.");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rigidbody2D.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWayPointDistance)
            currentWaypoint++;
        return;
    }
}
