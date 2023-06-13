using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class cameraMovement : MonoBehaviour
{

    public Transform target;
    public Vector3 cameraOffset;
    public float followspeed =1;
    Vector3 velocity = Vector3.zero;
    public float minY = -1.7f;
    public bool shaket = false;
    public bool shaket1 = false;
    public AnimationCurve curve;
    public AnimationCurve curve1;
    public float duration = 1f;
    public bool postison = true;
    public PostProcessVolume vol;
    public int scenegraphic;

    // Start is called before the first frame update
    private void Start()
    {
        vol = GameObject.Find("MainCamera").GetComponent<PostProcessVolume>();
        scenegraphic = PlayerPrefs.GetInt("graphic");
        if (scenegraphic == 2)
        {
            vol.enabled = true;
        }
        if (scenegraphic == 3)
        {
            vol.enabled = false;
        }
    }
    public void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position + cameraOffset;
            Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, float.MinValue, float.MaxValue), Mathf.Clamp(targetPos.y, float.MinValue, float.MaxValue), targetPos.z);
            Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, followspeed * Time.deltaTime);
            transform.position = smoothPos;
            if (shaket==true)
            {
                StartCoroutine(Shaking());
                shaket = false;
                
            }
            if (shaket1 == true)
            {
                StartCoroutine(Shaking1());
                shaket1 = false;

            }

        }
 
    }
    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
    IEnumerator Shaking1()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve1.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }




}


