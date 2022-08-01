using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int currentHealth;
    [SerializeField] private Material m2;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shootable")
        {
            Destroy(collision.gameObject);
            Damage(1);
        }
    }

	public void Damage(int damageAmount)
	{
		currentHealth -= damageAmount;

        if(currentHealth == 1)
            GetComponentInChildren<SkinnedMeshRenderer>().material = m2;
		else if (currentHealth == 0) 
		    Destroy(gameObject);
    }

    void Start()
    {
        currentHealth = Random.Range(2,4);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Camera.main.transform.position, Time.deltaTime / 2f);
        gameObject.transform.LookAt(Camera.main.transform.position);
    }
}
