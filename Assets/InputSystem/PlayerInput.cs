//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/InputSystem/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7f80e358-8577-452e-8d3b-b850abb6b431"",
            ""actions"": [
                {
                    ""name"": ""FlipperRight"",
                    ""type"": ""Button"",
                    ""id"": ""27ca2e61-64f4-48c4-8eb9-c070d837edd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FlipperLeft"",
                    ""type"": ""Button"",
                    ""id"": ""bbf5efb7-0b57-4930-898f-e51a5a86f12d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BallLauncher"",
                    ""type"": ""Button"",
                    ""id"": ""f484203d-4b2b-4b2a-8b1f-9f2565148c8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e57e2b2b-3208-4331-9a67-2949695233ca"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipperRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d82f8ca-2e9e-416a-8b79-572ed7f76062"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipperRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b43975b-fd8a-422c-b0fb-63041fcce720"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipperLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40123fa4-90df-4205-9a48-5f8fd858f139"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlipperLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f5e7188-22e4-490d-9524-1de142836c2d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BallLauncher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6005686a-f047-48bd-a916-f13da407e09d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BallLauncher"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_FlipperRight = m_Player.FindAction("FlipperRight", throwIfNotFound: true);
        m_Player_FlipperLeft = m_Player.FindAction("FlipperLeft", throwIfNotFound: true);
        m_Player_BallLauncher = m_Player.FindAction("BallLauncher", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_FlipperRight;
    private readonly InputAction m_Player_FlipperLeft;
    private readonly InputAction m_Player_BallLauncher;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @FlipperRight => m_Wrapper.m_Player_FlipperRight;
        public InputAction @FlipperLeft => m_Wrapper.m_Player_FlipperLeft;
        public InputAction @BallLauncher => m_Wrapper.m_Player_BallLauncher;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @FlipperRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlipperRight;
                @FlipperRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlipperRight;
                @FlipperRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlipperRight;
                @FlipperLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlipperLeft;
                @FlipperLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlipperLeft;
                @FlipperLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlipperLeft;
                @BallLauncher.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBallLauncher;
                @BallLauncher.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBallLauncher;
                @BallLauncher.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBallLauncher;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FlipperRight.started += instance.OnFlipperRight;
                @FlipperRight.performed += instance.OnFlipperRight;
                @FlipperRight.canceled += instance.OnFlipperRight;
                @FlipperLeft.started += instance.OnFlipperLeft;
                @FlipperLeft.performed += instance.OnFlipperLeft;
                @FlipperLeft.canceled += instance.OnFlipperLeft;
                @BallLauncher.started += instance.OnBallLauncher;
                @BallLauncher.performed += instance.OnBallLauncher;
                @BallLauncher.canceled += instance.OnBallLauncher;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnFlipperRight(InputAction.CallbackContext context);
        void OnFlipperLeft(InputAction.CallbackContext context);
        void OnBallLauncher(InputAction.CallbackContext context);
    }
}
