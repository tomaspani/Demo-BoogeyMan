using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f;


    private float _mouseX, _mouseY;
    private float _xRotation = 0f;

    public Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 40f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * _mouseX);

    }
}
