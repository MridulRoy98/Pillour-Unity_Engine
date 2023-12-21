using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public GameObject[] color_options;
    int color_option;
    private void Update()
    {
        Player_Movement();
    }

    void Player_Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x + (-0.4f), transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+0.4f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (-0.4f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Option_Red")
        {
            Debug.Log("Option Red");
            color_option = 0;
            gameObject.GetComponent<Renderer>().material = color_options[0].GetComponent<Renderer>().material;
        }
        if (other.gameObject.name == "Option_Blue")
        {
            Debug.Log("Option Blue");
            color_option = 1;
            gameObject.GetComponent<Renderer>().material = color_options[1].GetComponent<Renderer>().material;
        }
        if (other.gameObject.name == "Option_Green")
        {
            Debug.Log("Option Green");
            color_option = 2;
            gameObject.GetComponent<Renderer>().material = color_options[2].GetComponent<Renderer>().material;
        }
        if (other.gameObject.name == "Option_Black")
        {
            color_option = 3;
            gameObject.GetComponent<Renderer>().material = color_options[3].GetComponent<Renderer>().material;
            Debug.Log("black capsule");
        }
    }
    public int get_color_option()
    {
        return color_option;
    }
}
