using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Linq;
using System;
using TMPro;

public class ArenaMaster : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    protected int numberOfPlayers;

    

    [SerializeField]
    protected GameObject curveTemplate;

    [SerializeField]
    protected Canvas gameCanvas;

    [SerializeField]
    protected SpawnSettings spawnSettings;

    [SerializeField]
    RectTransform startingPad;

    [SerializeField]
    GameObject numberLabelPrefab;

    [SerializeField]
    GameObject celebrateLabelPrefab;

    List<Player> players;

    CollisionMap globalMap;

    int lostPlayerCount;

    float startTime;

    [SerializeField]
    int matchCount;

    private void Start()
    {
        players = new List<Player>();
        lostPlayerCount = 0;
        startTime = 0f;

        globalMap = new CollisionMap();
        ResetMapWithBorder();

        OptionState existingOptions = GameObject.FindObjectOfType<OptionState>();

        if (existingOptions != null)
        {
            numberOfPlayers = existingOptions.PlayerCount;
            matchCount = existingOptions.RoundCount - 1;
        }

        for (int i=0; i<numberOfPlayers; i++)
        {
            GameObject curvePrefab = Instantiate(curveTemplate, GetStartPadLocation(i), GetRandomStartRotation(), gameCanvas.transform);
            if (numberOfPlayers > 1)
            { 
                Instantiate(numberLabelPrefab, GetStartPadLocation(i)+Vector3.up / 5f, Quaternion.identity, startingPad).GetComponent<TextMeshProUGUI>().text = (i+1).ToString();   
            }
            players.Add(new Player(curvePrefab, i, GetRandomStartColor()));
            players.Last().LoseHandler += OnPlayerLost;
            players.Last().SetCollisionMap(globalMap);
            players.Last().Stop();
            Curve.GapAttributes oldGap = players.Last().ActiveCurve.GapSettings;
            players.Last().ActiveCurve.GapSettings = new Curve.GapAttributes(oldGap.frequency, UnityEngine.Random.Range(0, 2f*Mathf.PI), oldGap.offset);
        }

        StartCoroutine(FancyReset(numberOfPlayers>1? spawnSettings.waitTime : 0f, 60f, 2f, -5f));

    }


    // Update is called once per frame
    void Update()
    {
    }

    Vector3 GetRandomStartLocation(float marginPercent = 0.1f)
    {
        float w = (1f - marginPercent) * gameCanvas.GetComponent<RectTransform>().rect.width / 2;
        float h = (1f - marginPercent) * gameCanvas.GetComponent<RectTransform>().rect.height / 2;

        float x = UnityEngine.Random.Range(-w, w);
        float y = UnityEngine.Random.Range(-h, h);
        return new Vector3(x, y, 0f) + gameCanvas.transform.position;
    }

    Quaternion GetRandomStartRotation()
    {
        float angle = UnityEngine.Random.Range(-180, 180);
        return Quaternion.Euler(0f, 0f, angle);
    }

    Vector3 GetStartPadLocation(int idIn)
    {
        float xPos = Utility.LinSpace(startingPad.rect.xMin, startingPad.rect.xMax, numberOfPlayers + 2).ElementAt(idIn+1);
        return new Vector3(xPos, (startingPad.rect.yMin + startingPad.rect.yMax)/2) + gameCanvas.transform.position;
    }

    Color GetRandomStartColor()
    {
        return UnityEngine.Random.ColorHSV(0f, 1f, 0.9f, 0.1f, 0.9f, 1f);
    }

    IEnumerator LaunchAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

       foreach (Player player in players)
       {
            player.Go();
       }
        startTime = Time.time;
    }

    IEnumerator ReturnToMenuAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        SceneLoader.LoadPrevScene();
    }

    void OnPlayerLost(object sender, Player.LoseEventArgs loserArgs)
    {
        players[loserArgs.LoserId].Score--;
        lostPlayerCount++;
        if (lostPlayerCount >= players.Count-1)
        {

            if (matchCount <= 0) StartCoroutine(numberOfPlayers < 2 ? ReturnToMenuAfterTime(spawnSettings.waitTime) : CelebrateWinner());
            else
            {
                matchCount--;
                

                foreach (var player in players)
                {
                    player.Stop();
                }

                StartCoroutine(FancyReset(2f, 60f, 2f, -5f));
            }

            ResetMapWithBorder();
            return;
        }
    }

    IEnumerator FancyReset(float retractTime, float framerate, float dampTime, float dampEig=-2f, bool returnToPad=false)
    {
        float tailDuration = Time.time - startTime;
        var expo = Utility.GetPowerFitExponent(0, tailDuration, retractTime);
        float frameTime = 1 / framerate;


        float endDerivative = Utility.GetPowerFitDerivative(expo, tailDuration);

        List<Vector2> targetStarts = players.Select(p =>(Vector2) (!returnToPad? (Vector2)GetRandomStartLocation(spawnSettings.borderMargin) : (Vector2)GetStartPadLocation(p.PlayerId))).ToList();
        IEnumerable<Vector2> startVels = players.Select(player => Vector2.zero);
        List<Vector2> C1 = players.Zip(targetStarts, (player, newPos) => (Vector2)player.ActiveCurve.Position - newPos).ToList();
        List<Vector2> C2 = C1.Zip(startVels, (c1, v) => v - c1 * dampEig).ToList();

        List<Quaternion> newRotations = Enumerable.Range(0, players.Count).Select(x => GetRandomStartRotation()).ToList();
        List<Quaternion> oldRotations = players.Select(p => p.CurveRotation).ToList();

        for (int frame = 0; frame < retractTime*framerate; frame++)
        {
            yield return new WaitForSeconds(frameTime);
            foreach (var player in players)
            {
                player.CurveTrail.time = tailDuration - Utility.PowerFit(0, expo, frame * frameTime);
            }
            
        }

        foreach (var player in players)
        {
            player.CurveTrail.time = 0;
        }

        for (int frame = 0; frame < dampTime * framerate; frame++)
        {
            for( int i=0; i<players.Count; i++)
            {
                players[i].ActiveCurve.Position = Utility.DampedVector(C1[i], C2[i], targetStarts[i], dampEig, frame*frameTime);
                players[i].CurveRotation = Quaternion.Slerp(oldRotations[i], newRotations[i], Mathf.SmoothStep(0f, 1f, frame / dampTime / framerate));
            }
            yield return new WaitForSeconds(frameTime);
        }

        if (returnToPad) yield break;

        foreach(var player in players)
        {
            player.CurveTrail.time = Mathf.Infinity;
            player.Go();
        }
        startTime = Time.time;
        lostPlayerCount = 0;
        
    }

    IEnumerator CelebrateWinner()
    {
        foreach (var player in players)
        {
            player.Stop();
        }

        yield return FancyReset(2f, 60f, 2f, -5f, returnToPad: true);


        int winnerId = players.OrderByDescending(p => p.Score).First().PlayerId;
        
        Instantiate(celebrateLabelPrefab, GetStartPadLocation(winnerId) + Vector3.up / 3f, Quaternion.identity, startingPad);

        yield return ReturnToMenuAfterTime(6f);
    }

    void ResetMapWithBorder()
    {
        globalMap.OccupiedCoordinates.Clear();
        globalMap.AddBorder(gameCanvas.GetComponent<RectTransform>().rect.width, gameCanvas.GetComponent<RectTransform>().rect.height);
    }

    IEnumerable<Player> GetLivingPlayers()
    {
        foreach (var p in players) Debug.Log(p.ActiveCurve.DrawSettings.linearVelocity.ToString());
        return players.Where(p => p.ActiveCurve.DrawSettings.linearVelocity > 0f);
    }

    class Player
    {
        int playerId;

        int score;
        public int PlayerId { get => playerId;}

        GameObject curvePrefab;

        Curve activeCurve;

        TrailRenderer curveTrail;
        public Curve ActiveCurve { get => activeCurve; set => activeCurve = value; }

        Color lineColor;
        public Color LineColor
        {
            get => lineColor;
            set
            {
                lineColor = value;
                curveTrail.endColor = value;
                curveTrail.startColor = value;
                curvePrefab.GetComponentInChildren<SpriteRenderer>().color = value;
                curvePrefab.GetComponentInChildren<Light2D>().color = value;

                ParticleSystem.MainModule settings = curvePrefab.GetComponentInChildren<ParticleSystem>(true).main;
                settings.startColor = new ParticleSystem.MinMaxGradient(value);
            }
        }

        public void SetCollisionMap(CollisionMap map)
        {
            activeCurve.Map = map;
        }


        Curve.CurveAttributes startCurveAttributes;
        Curve.GapAttributes startGapAttributes;
        public Curve.CurveAttributes StartCurveAttributes { get => startCurveAttributes; set => startCurveAttributes = value; }
        public Curve.GapAttributes StartGapAttributes { get => startGapAttributes; set => startGapAttributes = value; }
        public TrailRenderer CurveTrail { get => curveTrail; set => curveTrail = value; }

        public Player(GameObject curvePrefab, int id, Color lineColor)
        {
            this.curvePrefab = curvePrefab;
            activeCurve = curvePrefab.GetComponentInChildren<Curve>();
            curveTrail = curvePrefab.GetComponent<TrailRenderer>();
            
            playerId = id;
            LineColor = lineColor;
            startCurveAttributes = Curve.CurveAttributes.Default;
            startGapAttributes = Curve.GapAttributes.Default;
            curvePrefab.GetComponentInChildren<CurveInput>().PlayerID = id;

            score = 0;

            activeCurve.CollisionHandler += CurveCollided;
        }

        void CurveCollided(object sender, EventArgs argsIn)
        {
            OnLose(new LoseEventArgs {LoserId=playerId});
        }

        public event EventHandler<LoseEventArgs> LoseHandler;
        protected virtual void OnLose(LoseEventArgs e)
        {
            LoseHandler?.Invoke(this, e);
        }

        public class LoseEventArgs : EventArgs
        {
            public int LoserId { get; set; }
        }

        public void Stop()
        {
            ActiveCurve.DrawSettings = Curve.CurveAttributes.Stopped;
            ActiveCurve.GapSettings = Curve.GapAttributes.Empty;
        }

        public void Go()
        {
            ActiveCurve.DrawSettings = startCurveAttributes;
            ActiveCurve.GapSettings = StartGapAttributes;
        }

        public Vector2 CurveVelocity
        {
            get
            {
                float r = ActiveCurve.DrawSettings.linearVelocity;
                float x = Mathf.Cos(ActiveCurve.Angle) * r;
                float y = Mathf.Sin(ActiveCurve.Angle) * r;
                return new Vector2(x, y);
            }
        }

        public Vector2 UsualVelocity
        {
            get
            {
                float r = StartCurveAttributes.linearVelocity;
                float x = Mathf.Cos(ActiveCurve.Angle) * r;
                float y = Mathf.Sin(ActiveCurve.Angle) * r;
                return new Vector2(x, y);
            }
        }

        public Quaternion CurveRotation
        {
            get
            {
                return Quaternion.Euler(0f, 0f, activeCurve.Angle / Mathf.PI * 180);
            }

            set
            {
                activeCurve.Angle = value.eulerAngles.z / 180 * Mathf.PI;
            }
        }

        public int Score { get => score; set => score = value; }
    }

    [Serializable]
    protected struct SpawnSettings
    {
        public float borderMargin;
        public float waitTime;

        public SpawnSettings(float borderMargin, float waitTime)
        {
            this.borderMargin = borderMargin;
            this.waitTime = waitTime;
        }
    }
}

