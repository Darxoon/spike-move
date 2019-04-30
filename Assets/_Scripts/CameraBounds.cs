using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Rect camBounds;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawLine(new Vector3(camBounds.x, camBounds.y), new Vector3(camBounds.x + camBounds.width, camBounds.y));
        Gizmos.DrawLine(new Vector3(camBounds.x, camBounds.y), new Vector3(camBounds.x, camBounds.y + camBounds.height));

        Gizmos.DrawLine(new Vector3(camBounds.x + camBounds.width, camBounds.y), new Vector3(camBounds.x + camBounds.width, camBounds.y + camBounds.height));
        Gizmos.DrawLine(new Vector3(camBounds.x, camBounds.y + camBounds.height), new Vector3(camBounds.x + camBounds.width, camBounds.y + camBounds.height));

        Gizmos.DrawLine(new Vector3(camBounds.x, camBounds.y), new Vector3(camBounds.x + camBounds.width, camBounds.y + camBounds.height));
    }
}
