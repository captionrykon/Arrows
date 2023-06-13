using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavadestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject particaldie;
    [SerializeField]
    private GameObject player;
  
    private void Awake()
    {
        particaldie.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            if (other != null)
            {

                Destroy(other.gameObject);
                particaldie.SetActive(true);
                Instantiate(particaldie, player.transform.position, player.transform.rotation);
                FindObjectOfType<UIManager>().gameOver(); 
            }

        }
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
