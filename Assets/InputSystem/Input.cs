// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Movment"",
            ""id"": ""ebac2b84-ca4c-4999-9985-a0c205d3986a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6524d653-b6cb-4b87-b568-dd9740fbbea4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""47ca43fc-6b7d-4b3a-a67e-ee7334d0cd3c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""4f4f9a0f-a472-4651-9db9-5c66ff0eb17d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2DAxis"",
                    ""id"": ""fdfb71f3-0852-4908-8d97-1da593ab06c0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1094e658-7fc2-4687-addb-d06a0907618a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8ee2cfd8-78b3-4187-bcf1-3663560f1f10"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""381513e5-f184-473c-a27f-cd18f9a86aec"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""798ea32b-2bc2-4028-8818-bad8c9cb5d28"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f3408084-8f7f-49ea-8610-4bcb729181e6"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d2b4af8-3b22-4f60-9fe5-4178fc4ca3ca"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movment
        m_Movment = asset.FindActionMap("Movment", throwIfNotFound: true);
        m_Movment_Move = m_Movment.FindAction("Move", throwIfNotFound: true);
        m_Movment_MouseDelta = m_Movment.FindAction("MouseDelta", throwIfNotFound: true);
        m_Movment_Interaction = m_Movment.FindAction("Interaction", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Movment
    private readonly InputActionMap m_Movment;
    private IMovmentActions m_MovmentActionsCallbackInterface;
    private readonly InputAction m_Movment_Move;
    private readonly InputAction m_Movment_MouseDelta;
    private readonly InputAction m_Movment_Interaction;
    public struct MovmentActions
    {
        private @Input m_Wrapper;
        public MovmentActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movment_Move;
        public InputAction @MouseDelta => m_Wrapper.m_Movment_MouseDelta;
        public InputAction @Interaction => m_Wrapper.m_Movment_Interaction;
        public InputActionMap Get() { return m_Wrapper.m_Movment; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovmentActions set) { return set.Get(); }
        public void SetCallbacks(IMovmentActions instance)
        {
            if (m_Wrapper.m_MovmentActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovmentActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovmentActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovmentActionsCallbackInterface.OnMove;
                @MouseDelta.started -= m_Wrapper.m_MovmentActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_MovmentActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_MovmentActionsCallbackInterface.OnMouseDelta;
                @Interaction.started -= m_Wrapper.m_MovmentActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_MovmentActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_MovmentActionsCallbackInterface.OnInteraction;
            }
            m_Wrapper.m_MovmentActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
            }
        }
    }
    public MovmentActions @Movment => new MovmentActions(this);
    public interface IMovmentActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
    }
}
