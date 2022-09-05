using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [Header("references")]
    public Transform cam;
    public Transform AttackPoint;
    public GameObject Candy;

    [Header("Settings")]
    public int Candies;
    public int MaxCandies;
    public float ThrowCD;
    public float ThrowMaxCD;
    public KeyCode ThrowKey;
    public float ThrowForce;
    public float ThrowUpwardForce;
    public bool CanThrow;


    private void Start()
    {
        CanThrow = true;
    }



    private void Update()
    {
        ThrowCD -= Time.deltaTime;
        if (ThrowCD <= 0 && Candies > 0)
        {
            CanThrow = true;
        }
        else
        { CanThrow = false; }
        if (CanThrow && Input.GetKeyDown(ThrowKey))
        {
            Throw();
        }
    }
    public void Throw ()
    {
        ThrowCD = ThrowMaxCD;
        GameObject ThrownCandy = Instantiate(Candy, AttackPoint.position, cam.rotation);

        Rigidbody CandyRB = ThrownCandy.GetComponent<Rigidbody>();

        Vector3 ForceDirection = cam.transform.forward;

        RaycastHit Hit;
        if (Physics.Raycast(cam.position, cam.forward, out Hit, 500f))
        {
            ForceDirection = (Hit.point - AttackPoint.position).normalized;
        }

        Vector3 ForceToAdd = ForceDirection * ThrowForce + transform.up * ThrowUpwardForce;
        CandyRB.AddForce(ForceToAdd, ForceMode.Impulse);
        Candies--;


    }
}
