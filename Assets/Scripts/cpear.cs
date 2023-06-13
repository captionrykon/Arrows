using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cpear : MonoBehaviour
{
    [SerializeField]
    Transform[] routes;
   
    private int routetogo;
    private float tparam;
    Vector2 objectpos;
    private float speedmodifier;
    private bool continueallowed;

    private void Start()
    {
        routetogo = 0;
        tparam = 0f;
        speedmodifier = 0.4f;
        continueallowed = true;

    }
    private void Update()
    {
        if (continueallowed)
        {
            StartCoroutine(gotheroutine(routetogo));
        }
    }
    private IEnumerator gotheroutine(int routinnumber)
    {
        continueallowed = false;
        Vector2 p0 = routes[routinnumber].GetChild(0).position;
        Vector2 p1 = routes[routinnumber].GetChild(1).position;
        Vector2 p2 = routes[routinnumber].GetChild(2).position;
        Vector2 p3 = routes[routinnumber].GetChild(3).position;
        while(tparam < 1)
        {
            tparam += Time.deltaTime * speedmodifier;
            objectpos = Mathf.Pow(1 - tparam, 3) * p0 +
                3 * Mathf.Pow(1 - tparam, 2) * tparam * p1 +
                3 * (1 - tparam) * Mathf.Pow(tparam, 2) * p2 +
                Mathf.Pow(tparam, 3) * p3;
            transform.position = objectpos;
            yield return new WaitForEndOfFrame();
        }
        tparam = 0f;
        routetogo += 1;
        if (routetogo > routes.Length - 1)
            routetogo = 0;

        continueallowed = true;
    }
}
