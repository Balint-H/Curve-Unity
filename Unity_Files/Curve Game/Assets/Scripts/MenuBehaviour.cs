using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
public class MenuBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked(Button button)
    {

    }

    public void NewGame()
    {
        var optionState = FindObjectOfType<OptionState>();
        optionState.CheckOptions();
        SceneLoader.LoadNextScene();
    }

    public void QuitGame()
    {
        SceneLoader.Quit();
    }
}
