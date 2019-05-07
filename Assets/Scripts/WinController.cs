using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinController : MonoBehaviour
{

    public Text winText;
    void Awake()
    {
        winText.enabled = false;
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        winText.enabled = true;
    }
}
