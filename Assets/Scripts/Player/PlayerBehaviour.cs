using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float speed;

    private CharacterController controller;

    [SerializeField]
    private float horizontalInput;
    [SerializeField]
    private float verticalInput;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private Vector3 finalSpeed;

    [SerializeField]
    private float mouseSensivity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        ReadInputs();
        HandleMovement();
        RotateCharacter();
    }

    private void ReadInputs()
    {
        //Read Input Values
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void HandleMovement()
    {
        //Direction dependent in the direction of the camera
        direction = Quaternion.Euler(0f, mainCamera.transform.eulerAngles.y, 0f) * new Vector3(horizontalInput, 0f, verticalInput);

        direction.Normalize();

        finalSpeed.x = direction.x * speed;
        finalSpeed.z = direction.z * speed;

        //Asign final Movement
        controller.Move(finalSpeed * Time.deltaTime);
    }

    private void RotateCharacter()
    {
        if (finalSpeed.magnitude != 0)
        {
            float rotationX = Input.GetAxis("Mouse X") * mouseSensivity;
            transform.Rotate(Vector3.up * rotationX * Time.deltaTime);

            Quaternion cameraRotation = mainCamera.transform.rotation;
            cameraRotation.x = 0f;
            cameraRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, cameraRotation, 0.1f);
        }
    }
}
