using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBoid : MonoBehaviour
{

    [SerializeField]
    float baseSpeed = 10.0f;

    [SerializeField]
    float sightRadius = 5.0f;

    [SerializeField]
    Vector3 gravityPoint = new Vector3(0.0f, 0.0f, 0.0f); //Defines the centerpoint the boids move too

    float speed;

    List<GameObject> nearbyBoids = new List<GameObject>(10);

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "PBoid";

        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Observe();//works with avoid script


        Cohere(); // Make them go in the same direction

        Align(); //Align Boids

        Avoid(); //Stops them from clashing and makes them flock

        Turnto(gravityPoint);//Move towards the selected point

        Move(); //Makes them move
    }

    void Observe()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, sightRadius);
        nearbyBoids.Clear();
        foreach (var col in colliders)
        {
            if (col.gameObject != gameObject && col.gameObject.tag == "PBoid")
            {
                Debug.Log(col.gameObject);

                nearbyBoids.Add(col.gameObject);
            }

        }
        //Debug.Log(colliders.Length);
        //Debug.Log("Nearby Boids: "+nearbyBoids.Count);
    }

    void Move()
    {
        //vector that tells you where the object is pointing
        transform.position += transform.up * speed * Time.deltaTime;

    }

    void Align()
    {
        if (nearbyBoids.Count > 0)
        {
            for (int i = 0; i < nearbyBoids.Count; ++i)
            {
                float angleDiff = Quaternion.Angle(transform.rotation, nearbyBoids[i].transform.rotation) * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, nearbyBoids[i].transform.rotation, angleDiff);
            }

        }
    }


    void Cohere()
    {
        if (nearbyBoids.Count > 0)
        {
            Vector3 centerOfMass = transform.position;
            for (int i = 0; i < nearbyBoids.Count; ++i)
            {
                centerOfMass += nearbyBoids[i].transform.position;
            }
            centerOfMass /= nearbyBoids.Count + 1;

            //calls on the function to move the object
            Turnto(centerOfMass);
        }
    }


    void Avoid()
    {
        if (nearbyBoids.Count > 0)
        {
            for (int i = 0; i < nearbyBoids.Count; ++i)
            {
                Vector3 toNeighbour = nearbyBoids[i].transform.position - transform.position;

                Turnto(transform.position - toNeighbour);  //too avoid the Neighbour boids
            }
        }
    }

    void Turnto(Vector3 turnTarget)
    {
        Quaternion lookRot = Quaternion.LookRotation(transform.forward, transform.up);
        Quaternion fromTo = Quaternion.FromToRotation(transform.up, (turnTarget - transform.position));

        Quaternion centerRot = fromTo * lookRot;
        //will define the compleate roation to target the center of mass


        float angleDiff = Quaternion.Angle(centerRot, transform.rotation) * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, centerRot, angleDiff);
    }


}