using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    int count = 0;
    public GameObject portalIn;
    public GameObject portalOut;
    //public GameObject cube;

    void teleport(GameObject portalIn, GameObject portalOut, GameObject cube)
    {
        GameObject newCube = Instantiate(cube, new Vector3(portalOut.transform.localPosition.x, portalOut.transform.localPosition.y - .2f, portalOut.transform.localPosition.z), Quaternion.identity);
        newCube.GetComponent<Rigidbody>().AddForce(cube.GetComponent<Rigidbody>().velocity);
        Debug.Log("cube" + count.ToString() + cube.GetComponent<Rigidbody>().velocity + "\n");
        Debug.Log("newCube" + count.ToString() + newCube.GetComponent<Rigidbody>().velocity + "\n");
        count++;
        Destroy(cube);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("other.gameObject.GetComponent<Rigidbody>().velocity = " + other.gameObject.GetComponent<Rigidbody>().velocity);
        
        teleport(portalIn, portalOut, other.gameObject);
    }
}
