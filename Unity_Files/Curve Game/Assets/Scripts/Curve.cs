using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class Curve : MonoBehaviour
{
    // Start is called before the first frame update

    internal float turnDirection;

    [SerializeField]
    float angle;

    RectTransform canvasTransform;
    TrailRenderer trail;

    [SerializeField]
    CurveAttributes drawSettings;

    [SerializeField]
    GapAttributes gapSettings;

    public CurveAttributes DrawSettings { get => drawSettings; set => drawSettings = value; }
    public GapAttributes GapSettings { get => gapSettings; set => gapSettings = value; }

    CollisionMap map;
    internal CollisionMap Map { get => map; set => map = value; }

    public float Angle 
    { 
        get => angle; 
        set
        {
            angle = value;
            canvasTransform.rotation = Quaternion.Euler(0f, 0f, angle/Mathf.PI*180f);
        }
    }

    public Vector3 Position
    {
        get => canvasTransform.position;

        set
        {
            canvasTransform.position = value;
        }
    }

    

    public event EventHandler CollisionHandler;
    protected virtual void OnCollision(EventArgs e)
    {
        DrawSettings = CurveAttributes.Stopped;
        CollisionHandler?.Invoke(this, e);
    }


    private void Awake()
    {
        canvasTransform = gameObject.GetComponent<RectTransform>();
        turnDirection = 0f;
        angle = canvasTransform.rotation.eulerAngles.z;
        trail = gameObject.GetComponent<TrailRenderer>();
        map = new CollisionMap(scale: 500f);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeStep = Time.deltaTime;

        Vector2 oldPos = canvasTransform.localPosition;

        Angle += GetAngleStep(timeStep);
        canvasTransform.position += GetSpacialStep(timeStep);
        canvasTransform.position += GetSpacialStep(timeStep);

        trail.emitting = GapSettings.ShouldDraw(Time.time);

        bool collided = false;
        if (trail.emitting)
        {
            collided = map.UpdateCollision(oldPos, canvasTransform.localPosition);
        }
        else
        {
            collided = map.CheckCollision(oldPos, canvasTransform.localPosition);
        }
        if (collided) OnCollision(new EventArgs());
    }

    float GetAngleStep(float dt)
    {
        return turnDirection * drawSettings.angularVelocity * dt;
    }

    Vector3 GetSpacialStep(float dt)
    {
        float r = dt * drawSettings.linearVelocity;
        float x = Mathf.Cos(Angle) * r;
        float y = Mathf.Sin(Angle) * r;
        return new Vector3(x, y);
    }


    [Serializable]
    public struct CurveAttributes
    {
        public float linearVelocity;
        public float angularVelocity;

        public CurveAttributes(float linearVelocity, float angularVelocity)
        {
            this.linearVelocity = linearVelocity;
            this.angularVelocity = angularVelocity;
        }

        public static CurveAttributes Default
        {
            get
            {
                return new CurveAttributes(2f, 4f);
            }
        }

        public static CurveAttributes Stopped
        {
            get
            {
                return new CurveAttributes(0f, 0f);
            }
        }

        public static CurveAttributes BlendTo(CurveAttributes a, CurveAttributes b, float t)
        {
            return new CurveAttributes(Mathf.SmoothStep(a.linearVelocity, b.linearVelocity, t), Mathf.SmoothStep(a.angularVelocity, b.angularVelocity, t));
        }

        public static CurveAttributes operator *(CurveAttributes a, float b)
        => new CurveAttributes(a.linearVelocity * b, a.angularVelocity*b);

    }

    [Serializable]
    public struct GapAttributes
    {
        public float frequency;
        public float phase;
        public float offset;

        public GapAttributes(float frequency, float phase, float offset)
        {
            this.frequency = frequency;
            this.phase = phase;
            this.offset = offset;
        }

        public bool ShouldDraw(float timeIn)
        {
            return (Mathf.Sin(frequency * timeIn + phase) + offset) > 0;
        }

        public static GapAttributes Default
        {
            get
            {
                return new GapAttributes(5f, -0.5f, 0.9f);
            }
        }

        public static GapAttributes Solid
        {
            get
            {
                return new GapAttributes(0f, 0f, 0.5f);
            }
        }

        public static GapAttributes Empty
        {
            get
            {
                return new GapAttributes(0f, 0f, -0.5f);
            }
        }

        public static GapAttributes BlendTo(GapAttributes a, GapAttributes b, float t)
        {
            return new GapAttributes(Mathf.SmoothStep(a.frequency, b.frequency, t), Mathf.SmoothStep(a.phase, b.phase, t), Mathf.SmoothStep(a.offset, b.offset, t));
        }


    }
}

class CollisionMap
{
    HashSet<Vector2> occupiedCoordinates;

    public HashSet<Vector2> OccupiedCoordinates { get => occupiedCoordinates; set => occupiedCoordinates = value; }

    float scale;

    public CollisionMap(float scale=500f)
    {
        occupiedCoordinates = new HashSet<Vector2>();
        this.scale = scale;
    }

    public bool TryAddCoords(IEnumerable<Vector2> coordsIn)
    {
        List<Vector2> l = coordsIn.ToList();
        List<bool> tr = coordsIn.Select(x => occupiedCoordinates.Contains(x)).ToList();

        return !coordsIn.Select(x => occupiedCoordinates.Add(x)).Any(x=>!x);

    }

    public bool TryCoords(IEnumerable<Vector2> coordsIn)
    {
        List<Vector2> l = coordsIn.ToList();
        List<bool> tr = coordsIn.Select(x => occupiedCoordinates.Contains(x)).ToList();
        bool res = !coordsIn.Select(x => occupiedCoordinates.Contains(x)).Any(x => x);
        return !coordsIn.Select(x => occupiedCoordinates.Contains(x)).Any(x => x);
    }

    public virtual bool UpdateCollision(Vector2 start, Vector2 target)
    {
        Vector2 diff = target - start;
        Vector2 offset = Mathf.Abs(diff.x) > Mathf.Abs(diff.y) ? Vector2.up / scale : Vector2.right / scale ;
        bool collision = !TryCoords(Bresenham.GenerateCoords(start + offset, target + offset, scale)) | !TryAddCoords(Bresenham.GenerateCoords(start, target, scale));
        return collision;

    }

    public virtual bool CheckCollision(Vector2 start, Vector2 target)
    {
        Vector2 diff = target - start;
        Vector2 offset = Mathf.Abs(diff.x) > Mathf.Abs(diff.y) ? Vector2.up / scale : Vector2.right / scale;
        bool collision = !TryCoords(Bresenham.GenerateCoords(start + offset, target + offset, scale)) | !TryCoords(Bresenham.GenerateCoords(start, target, scale));
        return collision;

    }

    public void AddBorder(float width, float height)
    {
        Vector2 bottomLeft = new Vector2(-width / 2, -height / 2);
        Vector2 topLeft = new Vector2(-width / 2, height / 2);
        Vector2 topRight = new Vector2(width / 2, height / 2);
        Vector2 bottomRight = new Vector2(width / 2, -height / 2);

        TryAddCoords(Bresenham.GenerateCoords(bottomLeft, topLeft, scale));
        TryAddCoords(Bresenham.GenerateCoords(topLeft, topRight, scale));
        TryAddCoords(Bresenham.GenerateCoords(topRight, bottomRight, scale));
        TryAddCoords(Bresenham.GenerateCoords(bottomRight, bottomLeft, scale));
    }

    static class Bresenham
    {
        public static IEnumerable<Vector2> GenerateCoords(Vector2 start, Vector2 target, float scale = 10)
        {
            Vector2Int positionDig = Vector2Int.RoundToInt(start * scale);
            Vector2Int targetDig = Vector2Int.RoundToInt(target * scale);

            Vector2Int diff =  targetDig - positionDig;

            Vector2Int d1 = new Vector2Int(Math.Sign(diff.x), Math.Sign(diff.y));
            Vector2Int d2 = new Vector2Int(d1.x, 0);

            int longest = Math.Abs(diff.x);
            int shortest = Math.Abs(diff.y);
            if (longest <= shortest)
            {
                longest = shortest;
                shortest = Math.Abs(diff.x);
                d2 = new Vector2Int(0, Math.Sign(diff.y));
            }
            int numerator = longest >> 1;

            for (int i = 0; i < longest; i++)
            {
                numerator += shortest;
                if (numerator >= longest)
                {
                    numerator -= longest;
                    positionDig += d1;
                }
                else
                {
                    positionDig += d2;
                }
                yield return positionDig;
            }
        }
    }
}

