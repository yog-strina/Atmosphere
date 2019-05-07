using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    int count = 0;
   // float speedLimit = 50f;
    public GameObject cubePrefab;
    public GameObject portalIn;
    public GameObject portalOut;

    private Vector3 posCubeIn;
    private Vector3 posCubeOut;
    private Vector3 posPortalIn;
    private Vector3 posPortalOut;

    void Start()
    {
        posPortalIn = portalIn.transform.localPosition;
        posPortalOut = portalOut.transform.localPosition;
    }

    void teleport(GameObject portalIn, GameObject portalOut, GameObject cube)
    {
        //posCubeOut = posPortalOut + (posPortalIn - posCubeIn) + (cubePrefab.GetComponent<Collider>().bounds.size) * -1;
        GameObject newCube = Instantiate(cubePrefab, new Vector3(portalOut.transform.localPosition.x, portalOut.transform.localPosition.y - (portalOut.transform.localRotation.z * 2.5f), portalOut.transform.localPosition.z), Quaternion.identity);
        if (cube.GetComponent<Rigidbody>().velocity.y < -50f)
            newCube.GetComponent<Rigidbody>().velocity = new Vector3(cube.GetComponent<Rigidbody>().velocity.x, -50f, cube.GetComponent<Rigidbody>().velocity.z);
        else
            newCube.GetComponent<Rigidbody>().velocity = cube.GetComponent<Rigidbody>().velocity;
        //Debug.Log("cube" + count.ToString() + cube.GetComponent<Rigidbody>().velocity + "\n");
        //Debug.Log("newCube" + count.ToString() + newCube.GetComponent<Rigidbody>().velocity + "\n");
        count++;
        Destroy(cube);
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("other.gameObject.GetComponent<Rigidbody>().velocity = " + other.gameObject.GetComponent<Rigidbody>().velocity);
        posCubeIn = other.gameObject.transform.localPosition;
        teleport(portalIn, portalOut, other.gameObject);
    }
}
