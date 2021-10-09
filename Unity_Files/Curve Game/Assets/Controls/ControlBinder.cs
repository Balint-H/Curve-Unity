using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class ControlBinder
{

    public enum BindActionId
    {
        TurnRight,
        TurnLeft,
        Special
    }

    public static InputAction GetPlayerTurnAction(this CurveControl inputManager, int playerId)
    {
        switch(playerId)
        {
            case 0:
                return inputManager.Gameplay1.Turn;
            case 1:
                return inputManager.Gameplay2.Turn;
            case 2:
                return inputManager.Gameplay3.Turn;
            case 3:
                return inputManager.Gameplay4.Turn;
            default:
                return inputManager.Gameplay1.Turn;
        }
    }

    public static InputAction GetPlayerUseAction(this CurveControl inputManager, int playerId)
    {
        switch (playerId)
        {
            case 0:
                return inputManager.Gameplay1.Use;
            case 1:
                return inputManager.Gameplay2.Use;
            case 2:
                return inputManager.Gameplay3.Use;
            case 3:
                return inputManager.Gameplay4.Use;
            default:
                return inputManager.Gameplay1.Use;
        }
    }

    public static InputAction GetPlayerSpecialAction(this CurveControl inputManager, int playerId)
    {
        switch (playerId)
        {
            case 0:
                return inputManager.Gameplay1.UseSpecial;
            case 1:
                return inputManager.Gameplay2.UseSpecial;
            case 2:
                return inputManager.Gameplay3.UseSpecial;
            case 3:
                return inputManager.Gameplay4.UseSpecial;
            default:
                return inputManager.Gameplay1.UseSpecial;
        }
    }


    public static void EnablePlayerCurveControls(this CurveControl inputManager, int playerId)
    {
        switch (playerId)
        {
            case 0:
                inputManager.Gameplay1.Enable();
                break;
            case 1:
                inputManager.Gameplay2.Enable();
                break;
            case 2:
                inputManager.Gameplay3.Enable();
                break;
            case 3:
                inputManager.Gameplay4.Enable();
                break;
            default:
                inputManager.Gameplay1.Enable();
                break;
        }
    }

    public static void DisablePlayerCurveControls(this CurveControl inputManager, int playerId)
    {
        switch (playerId)
        {
            case 0:
                inputManager.Gameplay1.Disable();
                break;
            case 1:
                inputManager.Gameplay2.Disable();
                break;
            case 2:
                inputManager.Gameplay3.Disable();
                break;
            case 3:
                inputManager.Gameplay4.Disable();
                break;
            default:
                inputManager.Gameplay1.Disable();
                break;
        }
    }

    public static string GetMapName(int playerId)
    {
        switch (playerId)
        {
            case 0:
                return "Gameplay1";
            case 1:
                return "Gameplay2";
            case 2:
                return "Gameplay3";
            case 3:
                return "Gameplay4";
            default:
                return "Gameplay1";
        }
    }

    /*    public static void RebindCurve(this InputAction action, BindActionId actionId, string rebindPath)
        {

            InputBinding inputBinding = action.bindings[(int)actionId];
            inputBinding.overridePath = path;
            action.ApplyBindingOverride(0, inputBinding);
        }*/

}
