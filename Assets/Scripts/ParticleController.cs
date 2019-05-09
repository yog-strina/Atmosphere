using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject _particle;

    void OnCollisionEnter(Collision coll)
    {
        Explode(coll.contacts);
    }

    void OnCollisionStay(Collision coll) {
        if (!coll.collider.CompareTag("Player"))
            Explode(coll.contacts);
    }

    void Explode(ContactPoint[] contacts)
    {
        foreach (ContactPoint contact in contacts)
        {
            GameObject particle = Instantiate(_particle, contact.point, Quaternion.identity);
        }
        //particle.GetComponent<ParticleSystem>().Play();
    }
}
