using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;

[Serializable, ]
public class InputAccess
{
    
    private InputAccess() //this class is private because I want have only one instance of it which is serialized field in Scriptable Object, I don't want have option to create it in other class
    {
        
    }
    
    [SerializeField] private InputActionProperty m_mouseDelta;
    public InputActionProperty MouseDelta => m_mouseDelta;

    [SerializeField] private InputActionProperty m_move;
    public InputActionProperty Move => m_move;

}
