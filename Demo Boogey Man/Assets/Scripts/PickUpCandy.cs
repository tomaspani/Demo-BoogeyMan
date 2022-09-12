using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCandy : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<ThrowObject>().Candies += 5;
        Destroy(gameObject);
    }
}
