using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class hexController : MonoBehaviour
{
    player_movement player;

    public Material []newMaterial;
    public GameObject[] hex_blocks; 
    public GameObject[] player_colliders;

    float bottNumber;
    float midNumber;
    float topNumber;

    bool mouseDown;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<player_movement>();
    }
    private void Update()
    {
        //setting ranges for the hexagons to shift up
        bottNumber = Random.Range(-25f, -10f);
        midNumber = Random.Range(-15f, -6f);
        topNumber = Random.Range(-8f, 1f);
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }
    }

    /*private void OnMouseDown()
    {
        mouseDown = true;
        Debug.Log("mousdown");
    }
    private void OnMouseUp()
    {
        mouseDown = false;
        Debug.Log("mousup");
    }*/

    //Checking with hexagons to move them a certain height
    private void OnTriggerEnter(Collider other)
    {
        
        if (gameObject.tag == "bott" && other.gameObject.tag == "hexagons")
        {
            other.gameObject.transform.position= new Vector3(other.transform.position.x, bottNumber, other.transform.position.z);
        }
        if (gameObject.tag == "mid" && other.gameObject.tag == "hexagons")
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, midNumber, other.transform.position.z);
            if (mouseDown)
            {
                other.gameObject.GetComponent<Renderer>().material = newMaterial[player.get_color_option()];
            }
        }
        if (gameObject.tag == "top" && other.gameObject.tag == "hexagons")
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, topNumber, other.transform.position.z);
            
        }
        if (gameObject.tag == "mid" && other.gameObject.name == "Reset")
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, midNumber, other.transform.position.z);
            if (mouseDown)
            {
                other.gameObject.GetComponent<Renderer>().material = newMaterial[player.get_color_option()];
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "bott" && other.gameObject.tag == "hexagons")
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, -25, other.transform.position.z);
            
        }
        if (gameObject.tag == "top" && other.gameObject.tag == "hexagons")
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, midNumber, other.transform.position.z);
        }
        if (gameObject.tag == "mid" && other.gameObject.tag == "hexagons")
        {
            other.gameObject.transform.position = new Vector3(other.transform.position.x, bottNumber, other.transform.position.z);
        }
    }
}
