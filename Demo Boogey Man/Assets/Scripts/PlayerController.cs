using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _xInput, _zInput;
    [SerializeField] private float speed;

    private CharacterController controller;

    private void Start()
    {
        controller = FindObjectOfType<CharacterController>();
    }

    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _zInput = Input.GetAxis("Vertical");


        var move = transform.right * _xInput + transform.forward * _zInput;

        controller.Move(move * speed * Time.deltaTime);
    }

    void kidnap (KidController kid)
    {
        kid.kidnap();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "kid")
        {
            Debug.Log("hola soy un nene");
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("a que no me secuestras xd");
                kidnap(other.GetComponent<KidController>());
            }
        }
    }


}
