using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility 
{
    public static Vector2 DampedVector(Vector2 c1, Vector2 c2, Vector2 targetVal, float eigenv, float sampleTime)
    {
        // c1 = startValue - targetVal;
        // c2 = startDerivative - c1 * eigenv;
        return targetVal + (c1 + c2 * sampleTime) * Mathf.Exp(eigenv * sampleTime);
    }

    public static Vector2 GetPowerFitExponent(Vector2 startVal, Vector2 targetVal, float totalTime)
    {
        var diff = targetVal - startVal;
        var logDiff = new Vector2(Mathf.Log(diff.x), Mathf.Log(diff.y));
        return logDiff / Mathf.Log(totalTime);
    }

    public static Vector2 GetPowerFitDerivative(Vector2 exponent, float sampleTime)
    {
        return exponent * new Vector2(Mathf.Pow(sampleTime, exponent.x - 1), Mathf.Pow(sampleTime, exponent.y - 1));
    }

    public static Vector2 PowerFit(Vector2 startValue, Vector2 exponent, float sampleTime)
    {
        return startValue + new Vector2(Mathf.Pow(sampleTime, exponent.x), Mathf.Pow(sampleTime, exponent.y));
    }

    public static float GetPowerFitExponent(float startVal, float targetVal, float totalTime)
    {
        var diff = targetVal - startVal;
        return Mathf.Log(diff, totalTime);
    }

    public static float GetPowerFitDerivative(float exponent, float sampleTime)
    {
        return exponent * Mathf.Pow(sampleTime, exponent - 1);
    }

    public static float PowerFit(float startValue, float exponent, float sampleTime)
    {
        return startValue + Mathf.Pow(sampleTime, exponent);
    }

    public static IEnumerable<float> LinSpace(float start, float end, int numElem)
    {
        for (int i = 0; i < numElem; i++)
        {
            yield return (float)i / (numElem - 1) * (end - start) + start;
        }
    }

}
