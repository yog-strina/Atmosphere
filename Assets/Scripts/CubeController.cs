using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public const int timeToDeath = 10;
    public const float blinkTime = .1f;
    public const float nonBlinkTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Blink");
        StartCoroutine("Kill");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Rigidbody>().velocity.x > 50)
            transform.GetComponent<Rigidbody>().velocity = new Vector3(50, transform.GetComponent<Rigidbody>().velocity.y, 0);
        if (transform.GetComponent<Rigidbody>().velocity.y > 50)
            transform.GetComponent<Rigidbody>().velocity = new Vector3(transform.GetComponent<Rigidbody>().velocity.x, 50, 0);
    }
 
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(1);
        int i = 0;
        while (++i > 0)
        {
            GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(blinkTime / i);
            GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(nonBlinkTime / i);
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(timeToDeath);
        Destroy(gameObject);
    }
}
