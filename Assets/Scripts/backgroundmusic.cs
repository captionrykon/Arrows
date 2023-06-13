using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmusic : MonoBehaviour
{
    public static backgroundmusic bginstance;
    public AudioSource Audio;
    private void Awake()
    {
        if(bginstance != null && bginstance!= this)
        {
            Destroy(this.gameObject);
            return;
        }
        bginstance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }


}
