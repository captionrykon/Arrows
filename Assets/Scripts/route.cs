using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class route : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlppoints;
    private Vector2 gizmosposition;

    private void OnDrawGizmos()
    {
        for(float t = 0;t<= 1; t += 0.05f)
        {
            gizmosposition = Mathf.Pow(1 - t, 3) * controlppoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * controlppoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * controlppoints[2].position +
                Mathf.Pow(t, 3) * controlppoints[3].position;
            Gizmos.DrawSphere(gizmosposition, 0.25f);
        }
        Gizmos.DrawLine(new Vector2(controlppoints[0].position.x, controlppoints[0].position.y),
            new Vector2(controlppoints[1].position.x, controlppoints[1].position.y));

        Gizmos.DrawLine(new Vector2(controlppoints[2].position.x, controlppoints[2].position.y),
            new Vector2(controlppoints[3].position.x, controlppoints[3].position.y));
        
    }
}
