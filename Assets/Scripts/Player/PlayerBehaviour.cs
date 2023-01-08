using System.Collections;
using System.Collections.Generic;
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
}
