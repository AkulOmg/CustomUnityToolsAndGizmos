using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //bullet directional movement and damage

    Rigidbody rb;
    public float damage = 34f;
    public bool spawn;
    public GameObject spawnObject;

    public void ApplyVel(Vector3 dir, float speed)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = dir * speed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (spawn) //If selected "Projectire" will also spawn items specified in inspector
        {
            GameObject.Instantiate(spawnObject, transform.position, Quaternion.identity);
            Debug.Log("Fired");
        }

        Destroy(gameObject); //bullet will be destroyed after 5 seconds
    }

}