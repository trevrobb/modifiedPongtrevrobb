using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

   

    bool p1tooFarDown;
    bool p1tooFarUp;

    bool p2tooFarDown;
    bool p2tooFarUp;

    void Start()
    {
        p1tooFarDown = false;
        p1tooFarUp = false;
        p2tooFarUp = false;
        p2tooFarDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 up = new Vector3(-1, 0, 0) * speed;
        Vector3 down = new Vector3(1, 0, 0) * speed;

        if (this.gameObject.tag == "playerOne")
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (transform.position.x > -123)
                {
                    transform.position = (this.transform.position + up);
                }
               
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (transform.position.x < 146)
                {
                    transform.position = this.transform.position + down;
                }
                
            }
        }
        if (this.gameObject.tag == "playerTwo")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (transform.position.x > -123)
                {
                    transform.position = (this.transform.position + up);
                }
                

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (transform.position.x < 146)
                {
                    transform.position = this.transform.position + down;
                }
                
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Pongball.instance.accelerate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (this.gameObject.CompareTag("playerOne"))
        {
            if (other.gameObject.CompareTag("box"))
            {
                p1tooFarDown = true;
            }
            if (other.gameObject.CompareTag("boxUp"))
            {
                p1tooFarUp = true;
            }
        }

        if (this.gameObject.CompareTag("playerTwo"))
        {
            if (other.gameObject.CompareTag("box"))
            {
                p2tooFarDown = true;
            }
            if (other.gameObject.CompareTag("boxUp"))
            {
                p2tooFarUp = true;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.CompareTag("playerOne"))
        {
            if (other.gameObject.CompareTag("box"))
            {
                p1tooFarDown = false;
            }
            if (other.gameObject.CompareTag("boxUp"))
            {
                p1tooFarUp = false;
            }
        }

        if (this.gameObject.CompareTag("playerTwo"))
        {
            if (other.gameObject.CompareTag("box"))
            {
                p2tooFarDown = false;
            }
            if (other.gameObject.CompareTag("boxUp"))
            {
                p2tooFarUp = false;
            }
        }
    }

   


}
