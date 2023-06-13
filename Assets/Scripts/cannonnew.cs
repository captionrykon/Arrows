using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonnew : MonoBehaviour
{
    public float timebenshots;
    public float maxTimebtnshoots;
    public GameObject bullet;
    [SerializeField] private Transform player;
    [SerializeField] private float detectiondistance;
    private float Sepration;
    public float duration ;
    private GameObject playerprefab;
    [SerializeField] private GameObject cannonPartical;
    [SerializeField] private GameObject cannonflotingtext;
    public cameraMovement cameram;
    // Start is called before the first frame update
    void Start()
    {
        playerprefab = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cameram = GameObject.Find("MainCamera").GetComponent<cameraMovement>();
        maxTimebtnshoots = timebenshots;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Sepration = Vector2.Distance(transform.position, player.position);
            if (Sepration <= detectiondistance)
            {
                if (maxTimebtnshoots <= 0)
                {
                    Instantiate(bullet, transform.position, Quaternion.identity);
                    maxTimebtnshoots = timebenshots;
                }
                else
                {
                    maxTimebtnshoots -= Time.deltaTime;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"&& cannonPartical!=null)
        {
            Destroy(this.gameObject);
         
            Instantiate(cannonPartical, transform.position, Quaternion.identity);
            cameram.shaket1 = true;
            if (cannonflotingtext!= null)
            {
                showflotingtextcannon();
            }
        }
    }
    public void showflotingtextcannon()
    {
        Instantiate(cannonflotingtext, transform.position, Quaternion.identity);
    }
    

}

