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
        if(Input.GetKeyDown(KeyCode.UpArrow))
            gameObject.transform.position = new Vector3(0,0,1f);

        //myTrans.RotateAround(myTrans.position,Vector3.right,5f);
        //gameObject.GetComponent<Rigidbody>().AddForce(5f*Vector3.up);
    }
}
