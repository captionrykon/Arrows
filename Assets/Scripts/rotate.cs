using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public GameObject Object;
    Vector2 GameobjectRotation;
    private float GameobjectRotation2;
    private float GameobjectRotation3;
    public bool rotateison = false;
    public bool FacingRight = false;
    public Vector2 movement;
    public Joystick joystick;
    void Update()
    {
        if (rotateison == true)
        {   
            
            //Gets the input from the jostick
            GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);

            GameobjectRotation3 = GameobjectRotation.x;

            if (FacingRight)
            {
                GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * 90;
                Object.transform.rotation = Quaternion.Euler(0f, 0f, GameobjectRotation2);
                //Rotates the object if the player is facing left

            }
            else
            {

                GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * -90;
                Object.transform.rotation = Quaternion.Euler(0f, 180f, -GameobjectRotation2);
                //Rotates the object if the player is facing right
            }
            if (GameobjectRotation3 < 0 && FacingRight)
            {
                // Executes the void: Flip()
                Flip();
            }
            else if (GameobjectRotation3 > 0 && !FacingRight)
            {
                // Executes the void: Flip()
                Flip();
            }
        }
    }
    private void Flip()
    {
        // Flips the player.
        FacingRight = !FacingRight;

        transform.Rotate(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y, gameObject.transform.localEulerAngles.z);
    }

    //public joystick joysticks;
    //Vector2 dirs;
    //public Rigidbody2D rb;
    //float _z;
    //float __z;
    //float z;
    // public bool followmouse = false;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //private void update()
    //{
    //    if (followmouse == true)
    //    {
    //        dirs = joysticks.joystickvec;
    //        dirs.x = joysticks.joystickvec.x;
    //        dirs.y = joysticks.joystickvec.y;
    //        float haxis = dirs.x;
    //        float vaxis = dirs.y;
    //        float zaxis = Mathf.Atan2(haxis, vaxis) * Mathf.Rad2Deg;
    //        transform.eulerAngles = new Vector3(0, 0, zaxis);
    //        if (z != 0)
    //        {
    //            _z = z;
    //            __z = z;
    //        }
    //        else
    //        {
    //            _z = __z;
    //        }
    //    }


    //    //dir.y = Input.GetAxisRaw("Vertical");
    //    //Vector3 moveVector = (Vector3.up * joystick.dir.x + Vector3.left * joystick.);
    //    //if (joystick.Horizontal != 0 || joystick.Vertical != 0)
    //    //{
    //    //    transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
    //    //}
    //    //var target = GameObject.Find("GameManager");
    //    //Vector3 newRotation = new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
    //    //this.transform.eulerAngles = newRotation;
    //}
    //private void FixedUpdate()
    //{
    //    rb.rotation = _z;

    //}
}
