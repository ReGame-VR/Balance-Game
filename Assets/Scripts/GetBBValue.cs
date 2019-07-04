using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBBValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Wii.GetBalanceBoard(0));
        Debug.Log(Wii.GetRawBalanceBoard(0));
    }
}
