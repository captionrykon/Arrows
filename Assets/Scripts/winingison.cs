using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winingison : MonoBehaviour
{
    [SerializeField]
    private GameObject winingpartical;
  
    public UIManager uiManager;
    public int currentsceneindex;
    private void Start()
    {
        uiManager = GameObject.Find("canvas").GetComponent<UIManager>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Instantiate(winingpartical, transform.position, Quaternion.identity);
        
            FindObjectOfType<UIManager>().winningison();
          

        }
    }
    

}
