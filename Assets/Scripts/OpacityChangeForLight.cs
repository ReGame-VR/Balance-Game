using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityChangeForLight : MonoBehaviour
{
    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        var image = light.GetComponent<Image>().color;
        image.a = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
