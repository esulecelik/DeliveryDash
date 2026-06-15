using NUnit.Framework;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float steerSpeed;
    float boostSpeed = 1;

    public bool hasPackage { get; set;}
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {   
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        transform.Rotate(0,0, steer * steerSpeed * Time.deltaTime );
        transform.Translate(0,move * moveSpeed * Time.deltaTime  * boostSpeed ,0);

  
    }


    public void speedUp()
    {
        boostSpeed = 2f;
    }

    public void slowDown()
    {
        boostSpeed = 1;
    }


}
