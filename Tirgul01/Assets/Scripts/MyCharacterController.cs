using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    private Transform myTrans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkControlButtons();
    }

    void checkControlButtons()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0,0,0.01f);
        if(Input.GetKey(KeyCode.DownArrow))
            transform.position += new Vector3(0,0,-0.01f);
        if(Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(0.01f,0,0);
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.position += new Vector3(-0.01f,0,0);  
        if(Input.GetAxis("Mouse X")<0)
            transform.RotateAround(transform.position,Vector3.up,-1f);
        if(Input.GetAxis("Mouse X")>0)
            transform.RotateAround(transform.position,Vector3.up,1f);
        if(Input.GetKey(KeyCode.Space))
            gameObject.GetComponent<Rigidbody>().AddForce(2f*Vector3.up);
    }
}
