using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
   public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D bc;
 
    public Transform target;
    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    public Joystick joysticks;
    public Camera cam;
    public rotate rotate;
    public float force;
    public float speed;
    public Vector2 movement;
    public float AngularSpeed;
    private bool boostison = false;
    [SerializeField] private GameObject boostbutton;
    [SerializeField] private GameObject playerboostpartical;
     private GameObject instantiateboostpartical;
    private Vector3 offset;
    [SerializeField]
    private GameObject particaldie;
    private UIManager uiManager;
    public Text scoreadd;
    // Start is called before the first frame update
    private void Awake()
    {
        uiManager = GameObject.Find("canvas").GetComponent<UIManager>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        target = GetComponentInChildren<Transform>();
        rotate = GameObject.Find("player").GetComponent<rotate>();
    }
  
    private void Update()
    {
        
        if (boostison == true)
        {
            movement.x = joysticks.Horizontal * speed*2.5f;
            movement.y = joysticks.Vertical * speed*5f;
        }
        else
        {
            if (joysticks.Horizontal >= 0.15f)
            {
                movement.x = joysticks.Horizontal * (speed * 1.2f);
            }
            else if (joysticks.Horizontal <= -0.15f)
            {
                movement.x = joysticks.Horizontal * (speed * 2f);
            }
            else
            {
                movement.x = joysticks.Horizontal * speed;
            }
            if (joysticks.Vertical >= 0.2f)
            {
                movement.y = joysticks.Vertical * (speed * 1.2f);
            }
            else if (joysticks.Vertical <= -0.2f)
            { 
                movement.y = joysticks.Vertical * (speed * 1.2f);
            }
            else
            {
                movement.y = joysticks.Vertical * speed;
            }
            
        }
       
        //movement = new Vector2(joysticks.Horizontal, joysticks.Vertical);
     
        //rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        float hAxis = joysticks.Vertical;
        float vAxis =joysticks.Horizontal;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, zAxis);
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(force, 0)+movement;
        //speed = rb.velocity.magnitude;
        //AngularSpeed = rb.angularVelocity;
        //rb.MovePosition(rb.position + movement * speed);
     
    }
    public void speedBoost()
    {
        boostison = true;
        boostbutton.SetActive(false);
        StartCoroutine(speedBoostCorutine());
    }
    public IEnumerator speedBoostCorutine()
    {
        playerboostpartical.SetActive(true);
        yield return new WaitForSeconds(4);
        boostison = false;
        playerboostpartical.SetActive(false);
      
        StartCoroutine(boosttimerCorutine());
    }
    
    //public void zoomOn()
    //{
    //    if (gameObject != null)
    //    {
    //        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,45, speed);
    //        cam.transform.position = Vector3.Lerp(cam.transform.position, gameObject.transform.position, speed);
    //    }
    //}
    //public void zoomNormal()
    //{
    //    if (gameObject != null)
    //    {
    //        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 58, speed);
    //        cam.transform.position = Vector3.Lerp(cam.transform.position, gameObject.transform.position, speed);
    //    }
    //}
    public IEnumerator boosttimerCorutine()
    {
        yield return new WaitForSeconds(20);
        boostbutton.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "myenemy")
        {
            if(boostison == true)
            {
                Destroy(other.gameObject);
               
              
            }
            if (boostison == false)
            {
                Destroy(this.gameObject);
                particaldie.SetActive(true);
                Instantiate(particaldie, transform.position, Quaternion.identity);
                FindObjectOfType<UIManager>().gameOver();

            }
        }
    }
   
}