using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionState : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private int playerCount;

    [SerializeField]
    private int roundCount;

    public static OptionState instance = null;

    [SerializeField]
    private PlayerCounter playerCounterObject;
    
    [SerializeField]
    private PlayerCounter roundCounterObject;


    private void OnLevelWasLoaded(int level)
    {
        if (level != 0) return;

        var counters = GameObject.FindObjectsOfType<PlayerCounter>();
        if (counters[0].name.Contains("Player"))
        {
            playerCounterObject = counters[0];
            roundCounterObject = counters[1];
        }
        else
        {
            playerCounterObject = counters[1];
            roundCounterObject = counters[0];
        }

        playerCounterObject.Count = playerCount;
        roundCounterObject.Count = roundCount;
    }


    public int PlayerCount
    {
        get => playerCount;
        set => playerCount = value;
    }
    public int RoundCount { get => roundCount; set => roundCount = value; }

    private void Awake()
    {

        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        playerCount = 1;
        roundCount = 1;
    }

    private void Start()
    {
        playerCounterObject.Count = playerCount;
        roundCounterObject.Count = roundCount;
    }

    public void CheckOptions()
    {
        playerCount = playerCounterObject.Count;
        roundCount = roundCounterObject.Count;
    }


}
