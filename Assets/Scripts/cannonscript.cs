using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonscript : MonoBehaviour
{   
    [SerializeField]private Transform player;
    public float speed;
    private Vector2 Target;
    [SerializeField]
    private GameObject particaldie;
    [SerializeField] private cameraMovement cameram;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Target = new Vector2(player.position.x, player.position.y);
        cameram = GameObject.Find("MainCamera").GetComponent<cameraMovement>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            particaldie.SetActive(true);
            Instantiate(particaldie, player.transform.position, player.transform.rotation);
            Destroy(this.gameObject);
            cameram.shaket1 = true;
            FindObjectOfType<UIManager>().gameOver();
        }
        if (other.gameObject.tag == "Lava")
        {
            Destroy(this.gameObject);
        }
    }

}