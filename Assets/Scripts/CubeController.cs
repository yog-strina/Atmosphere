using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int forceX = 100;
    public int forceY = 100;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(forceX, forceY, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
