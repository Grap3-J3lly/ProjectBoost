//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Input/KeyboardControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @KeyboardControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyboardControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyboardControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""84f72c88-bd5c-4948-b64f-9a5afcf40613"",
            ""actions"": [
                {
                    ""name"": ""Thrust"",
                    ""type"": ""Button"",
                    ""id"": ""ec566fed-e712-4dce-8976-b3508240307a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TiltLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f5d3af32-066b-4b61-bae9-fdaad4af1dc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TiltRight"",
                    ""type"": ""Button"",
                    ""id"": ""36cf4cb1-bce1-45c0-a54d-6872651f5b11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""70e47c47-939f-4344-bf81-0fa8fb3be15d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Thrust"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ba2d2d9-e8d0-4176-8d85-171a0e93ffd8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TiltLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64248bfd-3ae1-4a96-95e3-9508da8d1beb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TiltRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Thrust = m_Movement.FindAction("Thrust", throwIfNotFound: true);
        m_Movement_TiltLeft = m_Movement.FindAction("TiltLeft", throwIfNotFound: true);
        m_Movement_TiltRight = m_Movement.FindAction("TiltRight", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Thrust;
    private readonly InputAction m_Movement_TiltLeft;
    private readonly InputAction m_Movement_TiltRight;
    public struct MovementActions
    {
        private @KeyboardControls m_Wrapper;
        public MovementActions(@KeyboardControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Thrust => m_Wrapper.m_Movement_Thrust;
        public InputAction @TiltLeft => m_Wrapper.m_Movement_TiltLeft;
        public InputAction @TiltRight => m_Wrapper.m_Movement_TiltRight;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Thrust.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrust;
                @Thrust.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrust;
                @Thrust.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnThrust;
                @TiltLeft.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnTiltLeft;
                @TiltLeft.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnTiltLeft;
                @TiltLeft.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnTiltLeft;
                @TiltRight.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnTiltRight;
                @TiltRight.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnTiltRight;
                @TiltRight.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnTiltRight;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Thrust.started += instance.OnThrust;
                @Thrust.performed += instance.OnThrust;
                @Thrust.canceled += instance.OnThrust;
                @TiltLeft.started += instance.OnTiltLeft;
                @TiltLeft.performed += instance.OnTiltLeft;
                @TiltLeft.canceled += instance.OnTiltLeft;
                @TiltRight.started += instance.OnTiltRight;
                @TiltRight.performed += instance.OnTiltRight;
                @TiltRight.canceled += instance.OnTiltRight;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnThrust(InputAction.CallbackContext context);
        void OnTiltLeft(InputAction.CallbackContext context);
        void OnTiltRight(InputAction.CallbackContext context);
    }
}
