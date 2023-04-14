using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObject : MonoBehaviour
{
    //Lerp bewtwen positions movement
    [SerializeField]
    private Vector3 finalPosition = Vector3.zero;

    [SerializeField]
    private float duration;

    [SerializeField]
    private float lerpFactor;

    [SerializeField]
    private float time;

    // -1 GoBack 1 GoForward
    [SerializeField]
    private float direction;

    [SerializeField]
    private Vector3 originalPosition;

    [SerializeField]
    private GameObject finalObject;

    //Material Test Lerp Chage Color
    [SerializeField]
    private Material currentMaterrial;

    //Past material or future material
    [SerializeField]
    private Material finalMaterial;

    [SerializeField]
    private Vector4 originalColor;

    [SerializeField]
    private Vector4 finalColor;

    [SerializeField]
    private Renderer gameObjectRenderer;


    private void Awake()
    {
        gameObjectRenderer = GetComponent<Renderer>();
        currentMaterrial = gameObjectRenderer.material;

        //Position
        originalPosition = transform.position;
        finalPosition = finalObject.transform.position;

        //Material
        originalColor = currentMaterrial.color;
        finalColor = finalMaterial.color;


        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            CountTime();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GoForward();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GoBack();
        }
        lerpFactor = time / duration;

        //Movement
        if(finalPosition != Vector3.zero)
        {
            transform.position = Vector3.Lerp(originalPosition, finalPosition, lerpFactor);
        }

        //Material
        if(finalColor != Vector4.zero)
        {
            gameObjectRenderer.material.color = Vector4.Lerp(originalColor, finalColor, lerpFactor);
        }
        
        
    }

    private void CountTime()
    {
        time += Time.deltaTime * direction;
        if(time < 0f) time = 0f;
        if(time > duration) time = duration;
    }
    private void GoForward()
    {
        direction = 1f;
    }

    private void GoBack()
    {
        direction = -1f;
    }
 
}
