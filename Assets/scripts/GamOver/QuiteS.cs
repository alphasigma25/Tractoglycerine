using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuiteS : MonoBehaviour
{
    

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnAction1 (InputValue value)
    {
        if (value.isPressed)
        {
            Application.Quit();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
