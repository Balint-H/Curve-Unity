using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public static class Powers
{

    public static IEnumerator SpeedUp(CurveInput inputObject, float duration)
    {
        if (inputObject.PowerIsActive) yield break;
        inputObject.PowerIsActive = true;

        inputObject.SparklerFX.SetActive(true);

        inputObject.HeadlightsAnimator.Play("HeadlightNarrow");

        yield return ChangeSpeed(inputObject.ControlledCurve, 1.5f, duration);

        inputObject.HeadlightsAnimator.Play("HeadlightNarrowOff");
        inputObject.SparklerFX.SetActive(false);

        inputObject.PowerIsActive = false;
    }

    public static IEnumerator SlowDown(CurveInput inputObject, float duration)
    {
        yield return new WaitForSeconds(0.2f);
        if (inputObject.PowerIsActive) yield break;
        inputObject.PowerIsActive = true;

        inputObject.HeadlightsAnimator.Play("HeadlightBroad");

        yield return ChangeSpeed(inputObject.ControlledCurve, 0.5f, duration);

        inputObject.HeadlightsAnimator.Play("HeadlightBroadOff");


        inputObject.PowerIsActive = false;
    }

    public static IEnumerator ChangeSpeed(Curve curveIn, float multiplier,  float duration)
    {
        yield return ChangeSettingsRoutine(duration, 0.5f, curveIn, curveIn.DrawSettings * multiplier, curveIn.GapSettings);
    }

    static IEnumerator ChangeSettingsRoutine(float duration, float transitionTime, Curve curveIn, Curve.CurveAttributes drawSettings, Curve.GapAttributes gapSettings, float framerate = 60f)
    {
        Curve.CurveAttributes originalDrawSettings = curveIn.DrawSettings;
        Curve.GapAttributes originalGapSettings= curveIn.GapSettings;

        float frameTime = 1 / framerate;
        for (int frame = 0; frame <  transitionTime*framerate; frame++)
        {
            if (curveIn.DrawSettings.linearVelocity == 0f) yield break;
            curveIn.DrawSettings = Curve.CurveAttributes.BlendTo(originalDrawSettings, drawSettings, frame / transitionTime / framerate);
            curveIn.GapSettings = Curve.GapAttributes.BlendTo(originalGapSettings, gapSettings, frame / transitionTime / framerate);
            yield return new WaitForSeconds(frameTime);
        }

        yield return new WaitForSeconds(duration);

        for (int frame = 0; frame < transitionTime * framerate; frame++)
        {
            if (curveIn.DrawSettings.linearVelocity == 0f) yield break;
            curveIn.DrawSettings = Curve.CurveAttributes.BlendTo(drawSettings, originalDrawSettings, frame / transitionTime / framerate);
            curveIn.GapSettings = Curve.GapAttributes.BlendTo(gapSettings, originalGapSettings, frame / transitionTime / framerate);
            yield return new WaitForSeconds(frameTime);
        }

    }
}
