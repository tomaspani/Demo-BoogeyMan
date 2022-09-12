using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float _xInput, _zInput;
    [SerializeField] private float speed;

    private CharacterController controller;
    public Camera mainCamera;

    public float suspicion;
    public int kidnappedKids; 
    public Text text;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
        kidnappedKids++;
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

   

    public void addSuspicion(float val)
    {
        suspicion += val;
      

    }

    public void looseSuspicion(float val)
    {
        suspicion -= val;
        if(suspicion < 0f)
        {
            suspicion = 0f;
        }
    }


    

}
