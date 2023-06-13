
using UnityEngine;

public class destroyscript : MonoBehaviour
{
    public float destroyTime = 1.2f;
    public Vector3 offset = new Vector3(0, 1.2f, 0);
    public Vector3 randomx = new Vector3(0.5f, 0, 0);

    void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomx.x, randomx.x), Random.Range(-randomx.y, randomx.y), Random.Range(-randomx.z, randomx.z));
    }

}
