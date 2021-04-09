using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float areaRadius;
    public float speed;
    public bool showNodeHandles;
    public Vector3[] nodePoints;

    public Quaternion[] nodePointsRotations;
    void Start()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, areaRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * speed);
        Gizmos.color = Color.yellow;
        for (int i = 0; i < nodePoints.Length; i++)
        {
            Gizmos.DrawSphere(nodePoints[i], areaRadius);
        }
        Gizmos.color = Color.red;

        for (int i = 0; i < nodePoints.Length; i++)
        {
            Gizmos.DrawLine(nodePoints[i], nodePoints[(int)Mathf.Repeat(i + 1, nodePoints.Length)]);
        }

        Gizmos.DrawIcon(transform.position, "user.png");
    }

    private void OnDrawGizmosSelected()
    {

    }

}
