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
    
    private PlayerInput m_playerInputActionAsset;
    public PlayerInput PlayerInput => m_playerInputActionAsset;
    [SerializeField] private InputActionAsset m_inputAsset;
    public InputActionAsset InputAsset => m_inputAsset;

    private const string m_actionUIMapId = "UI";
    public string ActionUIMapId => m_actionUIMapId;

    private const string m_actionMovementMapId = "Movement";
    public string ActionMovementMapId => m_actionMovementMapId;
    
    [SerializeField] private InputActionProperty m_mouseDelta;
    public InputActionProperty MouseDelta => m_mouseDelta;

    [SerializeField] private InputActionProperty m_move;
    public InputActionProperty Move => m_move;

    [SerializeField] private InputActionProperty m_interactionButton;
    public InputActionProperty InteractionButton => m_interactionButton;

    [SerializeField] private InputActionProperty m_closeUIButton;
    public InputActionProperty CloseUIButton => m_closeUIButton;

    [SerializeField] private InputActionProperty m_submitButton;
    public InputActionProperty SubmitButton => m_submitButton;

    [SerializeField] private InputActionProperty m_shootAction;
    public InputActionProperty ShootAction => m_shootAction;

    public void ChangeMap(string actionMapId)
    {
        m_playerInputActionAsset.SwitchCurrentActionMap(actionMapId);
    }

    public void SetActionInputAsset(PlayerInput playerInput)
    {
        m_playerInputActionAsset = playerInput;
    }
}
