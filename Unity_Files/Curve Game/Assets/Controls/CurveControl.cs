// GENERATED AUTOMATICALLY FROM 'Assets/Controls/CurveControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CurveControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CurveControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CurveControl"",
    ""maps"": [
        {
            ""name"": ""Gameplay1"",
            ""id"": ""60aa8337-de15-4c69-8fde-b1f1b6bba860"",
            ""actions"": [
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""6b8e8f13-889c-4c44-89fd-ba0ef53a2b6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""8b93a8d5-3972-41d8-bc9e-f922409b9752"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Use Special"",
                    ""type"": ""Button"",
                    ""id"": ""84e8f241-1d60-45ff-ad75-8aba77767c6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                },
                {
                    ""name"": ""Return to Menu"",
                    ""type"": ""Button"",
                    ""id"": ""52f458e8-a82f-4193-a984-13917aa7aae2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""76018a4d-c418-4b43-a31f-2fec743c12f1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a43e2494-9bfd-4c00-aeae-4b604cae0af1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6ebd26d2-d954-45e4-9e7e-ab00c6752a4a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ae011d33-923e-4d55-a9a7-9cf411da1748"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96b50109-8dd6-4f14-ad21-5054cb2278a9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""585c2950-37df-4db5-baf4-c9050da276a0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return to Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay2"",
            ""id"": ""9809fe08-cdab-4491-914b-a5686f059217"",
            ""actions"": [
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""7231e41c-7ec5-4aff-ac9f-f7bd5c057d31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""0979a677-7fbd-43d9-86f3-30ec7a0f3335"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Special"",
                    ""type"": ""Button"",
                    ""id"": ""17695263-2959-43de-960b-c69c243fa8a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c0ed951c-7426-48ea-b029-11870d46c618"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c5a8832f-2841-404a-a2e8-95be837011e9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e367fc1b-0ab3-49ed-98c8-dc471d032b3b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""95df2a07-1401-4ca5-a705-1fb4f0736344"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56e22f8c-fb55-42c5-a882-d0d93eb11ed1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay3"",
            ""id"": ""d9358584-c95f-4ee9-9de6-db94e2d1b6bd"",
            ""actions"": [
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""b1eba07f-96fb-474b-914c-057b04ef7983"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""7b95e4e0-d1a1-408a-b82d-a295e1b14680"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Special"",
                    ""type"": ""Button"",
                    ""id"": ""4f1057a4-6c9d-47df-8040-1111a6a9cc39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6aed5035-4b29-481d-be29-9ff5efeba6ee"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e7917a7c-ad63-45f4-a52e-fab23e44f069"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0c683d3b-b352-47f9-a39a-287949d5aa1f"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e988422c-1875-4a5f-bac7-796e821ba19b"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50fd56ab-04d9-4fe1-973c-452b1216cc77"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay4"",
            ""id"": ""c0a45c1e-4a7b-4136-823b-15c9363b66e8"",
            ""actions"": [
                {
                    ""name"": ""Turn"",
                    ""type"": ""Value"",
                    ""id"": ""07e28a5b-0afb-4f1b-a223-8470099a5971"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""75aed61d-2ff9-4d55-bcc7-fe51c00800db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Special"",
                    ""type"": ""Button"",
                    ""id"": ""8e0c9588-50c7-4fcc-88f4-4f82380a782b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""MultiTap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""fe8edc64-6244-4186-b02b-2f59861f65a1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""759c713d-43b5-489f-ba46-27085167781f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f46954ed-008c-43d7-83e3-c0713a160e11"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fbb67699-a689-481a-805e-5e4f817ef922"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b87a25c-7cb7-4c61-ac22-955eec92bd49"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay1
        m_Gameplay1 = asset.FindActionMap("Gameplay1", throwIfNotFound: true);
        m_Gameplay1_Turn = m_Gameplay1.FindAction("Turn", throwIfNotFound: true);
        m_Gameplay1_Use = m_Gameplay1.FindAction("Use", throwIfNotFound: true);
        m_Gameplay1_UseSpecial = m_Gameplay1.FindAction("Use Special", throwIfNotFound: true);
        m_Gameplay1_ReturntoMenu = m_Gameplay1.FindAction("Return to Menu", throwIfNotFound: true);
        // Gameplay2
        m_Gameplay2 = asset.FindActionMap("Gameplay2", throwIfNotFound: true);
        m_Gameplay2_Turn = m_Gameplay2.FindAction("Turn", throwIfNotFound: true);
        m_Gameplay2_Use = m_Gameplay2.FindAction("Use", throwIfNotFound: true);
        m_Gameplay2_UseSpecial = m_Gameplay2.FindAction("Use Special", throwIfNotFound: true);
        // Gameplay3
        m_Gameplay3 = asset.FindActionMap("Gameplay3", throwIfNotFound: true);
        m_Gameplay3_Turn = m_Gameplay3.FindAction("Turn", throwIfNotFound: true);
        m_Gameplay3_Use = m_Gameplay3.FindAction("Use", throwIfNotFound: true);
        m_Gameplay3_UseSpecial = m_Gameplay3.FindAction("Use Special", throwIfNotFound: true);
        // Gameplay4
        m_Gameplay4 = asset.FindActionMap("Gameplay4", throwIfNotFound: true);
        m_Gameplay4_Turn = m_Gameplay4.FindAction("Turn", throwIfNotFound: true);
        m_Gameplay4_Use = m_Gameplay4.FindAction("Use", throwIfNotFound: true);
        m_Gameplay4_UseSpecial = m_Gameplay4.FindAction("Use Special", throwIfNotFound: true);
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

    // Gameplay1
    private readonly InputActionMap m_Gameplay1;
    private IGameplay1Actions m_Gameplay1ActionsCallbackInterface;
    private readonly InputAction m_Gameplay1_Turn;
    private readonly InputAction m_Gameplay1_Use;
    private readonly InputAction m_Gameplay1_UseSpecial;
    private readonly InputAction m_Gameplay1_ReturntoMenu;
    public struct Gameplay1Actions
    {
        private @CurveControl m_Wrapper;
        public Gameplay1Actions(@CurveControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Turn => m_Wrapper.m_Gameplay1_Turn;
        public InputAction @Use => m_Wrapper.m_Gameplay1_Use;
        public InputAction @UseSpecial => m_Wrapper.m_Gameplay1_UseSpecial;
        public InputAction @ReturntoMenu => m_Wrapper.m_Gameplay1_ReturntoMenu;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay1Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay1Actions instance)
        {
            if (m_Wrapper.m_Gameplay1ActionsCallbackInterface != null)
            {
                @Turn.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnTurn;
                @Use.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnUse;
                @UseSpecial.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnUseSpecial;
                @UseSpecial.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnUseSpecial;
                @UseSpecial.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnUseSpecial;
                @ReturntoMenu.started -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnReturntoMenu;
                @ReturntoMenu.performed -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnReturntoMenu;
                @ReturntoMenu.canceled -= m_Wrapper.m_Gameplay1ActionsCallbackInterface.OnReturntoMenu;
            }
            m_Wrapper.m_Gameplay1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @UseSpecial.started += instance.OnUseSpecial;
                @UseSpecial.performed += instance.OnUseSpecial;
                @UseSpecial.canceled += instance.OnUseSpecial;
                @ReturntoMenu.started += instance.OnReturntoMenu;
                @ReturntoMenu.performed += instance.OnReturntoMenu;
                @ReturntoMenu.canceled += instance.OnReturntoMenu;
            }
        }
    }
    public Gameplay1Actions @Gameplay1 => new Gameplay1Actions(this);

    // Gameplay2
    private readonly InputActionMap m_Gameplay2;
    private IGameplay2Actions m_Gameplay2ActionsCallbackInterface;
    private readonly InputAction m_Gameplay2_Turn;
    private readonly InputAction m_Gameplay2_Use;
    private readonly InputAction m_Gameplay2_UseSpecial;
    public struct Gameplay2Actions
    {
        private @CurveControl m_Wrapper;
        public Gameplay2Actions(@CurveControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Turn => m_Wrapper.m_Gameplay2_Turn;
        public InputAction @Use => m_Wrapper.m_Gameplay2_Use;
        public InputAction @UseSpecial => m_Wrapper.m_Gameplay2_UseSpecial;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay2Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay2Actions instance)
        {
            if (m_Wrapper.m_Gameplay2ActionsCallbackInterface != null)
            {
                @Turn.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnTurn;
                @Use.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnUse;
                @UseSpecial.started -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnUseSpecial;
                @UseSpecial.performed -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnUseSpecial;
                @UseSpecial.canceled -= m_Wrapper.m_Gameplay2ActionsCallbackInterface.OnUseSpecial;
            }
            m_Wrapper.m_Gameplay2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @UseSpecial.started += instance.OnUseSpecial;
                @UseSpecial.performed += instance.OnUseSpecial;
                @UseSpecial.canceled += instance.OnUseSpecial;
            }
        }
    }
    public Gameplay2Actions @Gameplay2 => new Gameplay2Actions(this);

    // Gameplay3
    private readonly InputActionMap m_Gameplay3;
    private IGameplay3Actions m_Gameplay3ActionsCallbackInterface;
    private readonly InputAction m_Gameplay3_Turn;
    private readonly InputAction m_Gameplay3_Use;
    private readonly InputAction m_Gameplay3_UseSpecial;
    public struct Gameplay3Actions
    {
        private @CurveControl m_Wrapper;
        public Gameplay3Actions(@CurveControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Turn => m_Wrapper.m_Gameplay3_Turn;
        public InputAction @Use => m_Wrapper.m_Gameplay3_Use;
        public InputAction @UseSpecial => m_Wrapper.m_Gameplay3_UseSpecial;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay3; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay3Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay3Actions instance)
        {
            if (m_Wrapper.m_Gameplay3ActionsCallbackInterface != null)
            {
                @Turn.started -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnTurn;
                @Use.started -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnUse;
                @UseSpecial.started -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnUseSpecial;
                @UseSpecial.performed -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnUseSpecial;
                @UseSpecial.canceled -= m_Wrapper.m_Gameplay3ActionsCallbackInterface.OnUseSpecial;
            }
            m_Wrapper.m_Gameplay3ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @UseSpecial.started += instance.OnUseSpecial;
                @UseSpecial.performed += instance.OnUseSpecial;
                @UseSpecial.canceled += instance.OnUseSpecial;
            }
        }
    }
    public Gameplay3Actions @Gameplay3 => new Gameplay3Actions(this);

    // Gameplay4
    private readonly InputActionMap m_Gameplay4;
    private IGameplay4Actions m_Gameplay4ActionsCallbackInterface;
    private readonly InputAction m_Gameplay4_Turn;
    private readonly InputAction m_Gameplay4_Use;
    private readonly InputAction m_Gameplay4_UseSpecial;
    public struct Gameplay4Actions
    {
        private @CurveControl m_Wrapper;
        public Gameplay4Actions(@CurveControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Turn => m_Wrapper.m_Gameplay4_Turn;
        public InputAction @Use => m_Wrapper.m_Gameplay4_Use;
        public InputAction @UseSpecial => m_Wrapper.m_Gameplay4_UseSpecial;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay4; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Gameplay4Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplay4Actions instance)
        {
            if (m_Wrapper.m_Gameplay4ActionsCallbackInterface != null)
            {
                @Turn.started -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnTurn;
                @Turn.performed -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnTurn;
                @Turn.canceled -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnTurn;
                @Use.started -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnUse;
                @UseSpecial.started -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnUseSpecial;
                @UseSpecial.performed -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnUseSpecial;
                @UseSpecial.canceled -= m_Wrapper.m_Gameplay4ActionsCallbackInterface.OnUseSpecial;
            }
            m_Wrapper.m_Gameplay4ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Turn.started += instance.OnTurn;
                @Turn.performed += instance.OnTurn;
                @Turn.canceled += instance.OnTurn;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @UseSpecial.started += instance.OnUseSpecial;
                @UseSpecial.performed += instance.OnUseSpecial;
                @UseSpecial.canceled += instance.OnUseSpecial;
            }
        }
    }
    public Gameplay4Actions @Gameplay4 => new Gameplay4Actions(this);
    public interface IGameplay1Actions
    {
        void OnTurn(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnUseSpecial(InputAction.CallbackContext context);
        void OnReturntoMenu(InputAction.CallbackContext context);
    }
    public interface IGameplay2Actions
    {
        void OnTurn(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnUseSpecial(InputAction.CallbackContext context);
    }
    public interface IGameplay3Actions
    {
        void OnTurn(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnUseSpecial(InputAction.CallbackContext context);
    }
    public interface IGameplay4Actions
    {
        void OnTurn(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnUseSpecial(InputAction.CallbackContext context);
    }
}
