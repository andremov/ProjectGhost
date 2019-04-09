using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Experimental.UIElements;

public class HealthInterface : MonoBehaviour
{


    //public RectTransform background;
    //public RectTransform fill;

    float healthPercent = 1;
    public float DisplayedHealth
    {
        set
        {
            healthPercent = value;
            GetComponent<Slider>().value = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
