using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    // General
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject prefabGun;
    [SerializeField] private GameObject prefabBullet;

    private float m_Speed = 0.03f;

    // Shooting
    [SerializeField] private Transform gunStart;
    private GameObject gun;
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private float nextFire;

    void Start()
    {
        fpsCam = GetComponentInChildren<Camera>();
        addGun();
    }

    void Update()
    {
        checkControlButtons();
    }

    void addGun()
    {
        gun = (GameObject)Instantiate(prefabGun, transform);
        gun.transform.position += new Vector3(0.3f,0,0.6f);
        gun.transform.localScale = new Vector3(3f,3f,3f);
    }
    
    //camera: -0.006, 0.26, 0.2
    void checkControlButtons()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.forward * m_Speed;
        if(Input.GetKey(KeyCode.DownArrow))
            transform.position +=  -transform.forward * m_Speed;
        if(Input.GetKey(KeyCode.RightArrow))
            transform.position += transform.right * m_Speed;
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.position += -transform.right * m_Speed;
        if(Input.GetAxis("Mouse X")<0)
            transform.RotateAround(transform.position,Vector3.up,-1f);
        if(Input.GetAxis("Mouse X")>0)
            transform.RotateAround(transform.position,Vector3.up,1f);
        if(Input.GetKey(KeyCode.Space))
            gameObject.GetComponent<Rigidbody>().AddForce(5f*Vector3.up);
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
            shootProjectile();
        if (Input.GetMouseButtonDown(1))
            createEnemy();
    }

    void shootProjectile()
    {
        Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
        ray.origin = gunStart.transform.position;

        GameObject bullet = (GameObject)Instantiate(prefabBullet, ray.origin, Quaternion.identity);
        bullet.transform.LookAt(ray.origin + (ray.direction * 50f));
        Destroy(bullet, 5f);
        bullet.GetComponent<Rigidbody>().AddForce(ray.direction * 1000f);

        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow, Mathf.Infinity);
    }

    void createEnemy()
    {
        GameObject enemy = (GameObject)Instantiate(prefabEnemy, new Vector3(Random.Range(-5f,5f),1f,Random.Range(5f,10f)), Quaternion.identity);
        enemy.AddComponent<Rigidbody>();
        enemy.AddComponent<BoxCollider>();
        enemy.GetComponent<BoxCollider>().center = new Vector3(0,0.5f,0);
    }


}
