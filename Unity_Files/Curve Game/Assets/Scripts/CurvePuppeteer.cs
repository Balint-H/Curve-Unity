using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CurvePuppeteer : ArenaMaster
{
    [SerializeField]
    float startAngle;

    [SerializeField]
    float spawnPeriod;

    List<Puppeteer> puppeteers;

    [SerializeField]
    Puppeteer.PuppeteerAttributes puppeteerSettings;

    [SerializeField]
    RectTransform spawnArea;

    bool started = false;

    private void Start()
    {
        puppeteers = new List<Puppeteer>();
        StartCoroutine(SpawnPeriodically(spawnSettings.waitTime, spawnPeriod));
    }

    private void Update()
    {
        if (!started) return;

        foreach (Puppeteer puppeteer in puppeteers)
        {
            puppeteer.UpdateDirection();
            if (puppeteer.age < 0.2f)
            {
                puppeteer.puppetedCurve.GapSettings = Curve.GapAttributes.Solid;
            }
            if (puppeteer.age > 6.8f)
            {
                puppeteer.puppetedCurve.GapSettings = Curve.GapAttributes.Empty;
            }
            if (puppeteer.age > 7f)
            {
                puppeteer.puppetedCurve.Position = GetRandomStartLocation();
                puppeteer.puppetedCurve.Angle = startAngle;
                puppeteer.puppetedCurve.Map = new CollisionMap();
                puppeteer.age = 0f;
            }
        }
    }

    Vector3 GetRandomStartLocation()
    {
        Vector3[] corners = new Vector3[4];
        spawnArea.GetLocalCorners(corners);

        float x = UnityEngine.Random.Range(corners[0].x, corners[2].x);
        float y = UnityEngine.Random.Range(corners[0].y, corners[2].y);
        return new Vector3(x, y, 0f) + spawnArea.transform.position;
    }

    Quaternion GetRandomStartRotation()
    {
        return Quaternion.Euler(0f, 0f, startAngle);
    }

    Color GetRandomStartColor()
    {
        return UnityEngine.Random.ColorHSV(0f, 1f, 0.9f, 0.1f, 0.9f, 1f);
    }

    IEnumerator SpawnPeriodically(float delay, float spawnPeriod)
    {
        yield return new WaitForSeconds(delay);

        LazyCollisionMap fakeMap = new LazyCollisionMap();

        while(puppeteers.Count < numberOfPlayers)
        {
            GameObject curvePrefab = Instantiate(curveTemplate, GetRandomStartLocation(), GetRandomStartRotation(), gameCanvas.transform);
            Curve curCurve = curvePrefab.GetComponent<Curve>();
            GameObject.Destroy(curvePrefab.GetComponentInChildren<CurveInput>());
            curCurve.Map = fakeMap;
            curCurve.DrawSettings = Curve.CurveAttributes.Default;
            curCurve.GapSettings = Curve.GapAttributes.Solid;
            curCurve.Angle = startAngle;
            Color curveColor = GetRandomStartColor();
            curveColor.a = 0.5f;
            curvePrefab.GetComponentInChildren<SpriteRenderer>().color = curveColor;
            curvePrefab.GetComponentInChildren<Light2D>().intensity /= 20f;
            curvePrefab.GetComponentInChildren<SpriteRenderer>().sortingLayerID = 0;
            Color endColor = new Color(curveColor.r, curveColor.g, curveColor.b, 0f);
            curCurve.gameObject.GetComponent<TrailRenderer>().startColor = curveColor;
            
            curCurve.gameObject.GetComponent<TrailRenderer>().endColor = endColor;
            curCurve.gameObject.GetComponent<TrailRenderer>().time = 1.5f;


            Puppeteer puppeteer = new Puppeteer(curCurve, puppeteerSettings);
            puppeteers.Add(puppeteer);
            started = true;
            yield return new WaitForSeconds(spawnPeriod);
        }
        

    }

    class Puppeteer
    {
        public Curve puppetedCurve;

        public float age;

        PuppeteerAttributes settings;

        public float desiredAngle;

        float phase;


        public Puppeteer(Curve puppetedCurve, PuppeteerAttributes settings)
        {
            this.puppetedCurve = puppetedCurve;
            this.settings = settings;
            desiredAngle = puppetedCurve.Angle;
            phase = UnityEngine.Random.Range(0f, 5f);

        }

        public void UpdateDirection()
        {
            float dt = Time.deltaTime;
            age += dt;
            if (puppetedCurve.DrawSettings.linearVelocity == 0f) puppetedCurve.DrawSettings = Curve.CurveAttributes.Default;
            puppetedCurve.Angle = desiredAngle + (Mathf.PerlinNoise(0, Time.time/settings.timeScaler + phase)-0.5f)*settings.noiseMagnitude;

        }

        [Serializable]
        internal struct PuppeteerAttributes
        {
            public float timeScaler;
            public float noiseMagnitude;
        }
    }

    class LazyCollisionMap : CollisionMap
    {
        public override bool CheckCollision(Vector2 start, Vector2 target)
        {
            return false;
        }

        public override bool UpdateCollision(Vector2 start, Vector2 target)
        {
            return false;
        }
    }
    
    

}
