using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class offthepost : MonoBehaviour
{
    public PostProcessVolume vol;
    public bool postoff;
    // Start is called before the first frame update
    void Start()
    {
        vol = GameObject.Find("MainCamera").GetComponent<PostProcessVolume>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if (postoff == true)
        {
            vol.enabled = false;
        }
    }
}
