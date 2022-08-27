using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidController : MonoBehaviour
{
    public Text feedback;

    private void Update()
    {
        //feedback.text = "";
    }


    private void OnTriggerEnter(Collider other)
    {
        feedback.text = "Press 'Mouse RB' to kidnap";
    }

    private void OnTriggerStay(Collider other)
    {
        feedback.text = "Press 'Mouse RB' to kidnap";
    }

    private void OnTriggerExit(Collider other)
    {
        feedback.text = "";
    }


    public void kidnap()
    {
        Debug.Log("me secuestraron lol");
        feedback.text = "";
        Destroy(this.gameObject);
    }
}
