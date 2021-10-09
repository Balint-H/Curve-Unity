using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI countText;

    private int count;

    [SerializeField]
    Slider countSlider;

    public int Count 
    { 
        get => count; 
        set
        {
            if (count == value) return;
            count = value;

            if (countText == null) countText = gameObject.GetComponent<TextMeshProUGUI>();

            countText.text = value.ToString();
            countSlider.value = value;
        }
    }

    
    void Start()
    {
        countText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCountr()
    {
        Count = (int)countSlider.value;
    }

}
