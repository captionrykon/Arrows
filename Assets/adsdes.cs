using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adsdes : MonoBehaviour
{
    public UIManager uiManager;
    private void Start()
    {
        uiManager = GameObject.Find("canvas").GetComponent<UIManager>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            uiManager.adsison = true;
            Destroy(this.gameObject);

        }
    }
}
