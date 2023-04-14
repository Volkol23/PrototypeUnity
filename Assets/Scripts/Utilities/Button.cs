using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject gameobjectButton;

    [SerializeField]
    private Vector3 originalPosition;

    [SerializeField]
    private bool pressed;

    [SerializeField]
    private float positionMove;

    [SerializeField]
    private float lerpTime;

    private void Awake()
    {
        originalPosition = gameObject.transform.position;
    }
    private void Update()
    {
        if (pressed)
        {
            transform.position = Vector3.Lerp(originalPosition, originalPosition + new Vector3(0, positionMove, 0), lerpTime);
        }
        else if (!pressed)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, lerpTime);
        }
    }
    private void ChangeButtton()
    {
        if (pressed)
        {
            pressed = false;
        } else if (!pressed)
        {
            pressed = true;
        }
    }
}
