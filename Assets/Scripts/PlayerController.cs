using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int objCount = 0;
    Vector3 mousePos;
    Vector3 worldPos;
    Vector3 prefabPos;
    Vector3 prefabVel;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && objCount < 3)
        {
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            prefabPos = new Vector3(gameObject.transform.localPosition.x + 1.2f, gameObject.transform.localPosition.y + 1.2f, gameObject.transform.localPosition.z);
            prefabVel = (worldPos - prefabPos).normalized;
            GameObject newObj = Instantiate(prefab, prefabPos, Quaternion.identity);
            newObj.GetComponent<Rigidbody>().velocity = prefabVel * 10;
            objCount++;
        }
    }
}
