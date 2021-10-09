using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.InputSystem;

public class CurveInput : MonoBehaviour
{
    CurveControl curveControl;

    float turnDirection;

    bool powerIsActive;


    [SerializeField]
    Curve controlledCurve;

    [SerializeField]
    Animator headlightsAnimator;

    [SerializeField]
    GameObject sparklerFX;

    int playerID;

    public Curve ControlledCurve
    {
        get => controlledCurve;
    }

    public float TurnDirection 
    { 
        get => turnDirection;
        set
        {
            turnDirection = value;
            controlledCurve.turnDirection = value;
        } 
    }

    public int PlayerID { get => playerID; set => playerID = value; }
    public bool PowerIsActive { get => powerIsActive; set => powerIsActive = value; }
    public Animator HeadlightsAnimator { get => headlightsAnimator; set => headlightsAnimator = value; }
    public GameObject SparklerFX { get => sparklerFX; set => sparklerFX = value; }

    // Start is called before the first frame update
    void Start()
    {
        InputAction turnAction = curveControl.GetPlayerTurnAction(playerID);
        InputAction useAction = curveControl.GetPlayerUseAction(playerID);
        InputAction specialAction = curveControl.GetPlayerSpecialAction(playerID);

        powerIsActive = false;

        turnAction.performed += ctx =>
        {
            TurnDirection = ctx.ReadValue<float>();
        };

        turnAction.canceled += ctx =>
        {
            TurnDirection = ctx.ReadValue<float>();
        };

        useAction.performed += ctx => StartCoroutine(Powers.SlowDown(this, 3f));
        specialAction.performed += ctx => StartCoroutine(Powers.SpeedUp(this, 3f));

        if (PlayerID == 0)
        {
            curveControl.Gameplay1.ReturntoMenu.performed += ctx => SceneLoader.LoadMenu();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        curveControl = new CurveControl();
        
        curveControl.bindingMask = InputBinding.MaskByGroup(ControlBinder.GetMapName(playerID));

    }

    private void OnEnable()
    {
        curveControl.Enable();
        curveControl.EnablePlayerCurveControls(playerID);
    }

    private void OnDisable()
    {
        curveControl.DisablePlayerCurveControls(playerID);
        curveControl.Disable();
    }

}
