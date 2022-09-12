using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCandy : MonoBehaviour
{
    [SerializeField] float DestroyCD;
    public float MaxDestroyCD;

    private void OnTriggerStay(Collider other)
    {
        DestroyCD -= Time.deltaTime;

    }
    // Update is called once per frame
    void Update()
    {
       if (DestroyCD <= 0)
        {
            Destroy(gameObject);
        } 
    }
}
