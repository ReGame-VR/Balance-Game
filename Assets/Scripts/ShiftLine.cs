using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftLine : MonoBehaviour
{
    Canvas myCanvas;

    private void Awake()
    {
        myCanvas = GameObject.FindObjectOfType<Canvas>();
        LineRenderer lR = this.gameObject.GetComponent<LineRenderer>();
        Vector3[] shiftedPositions = new Vector3[lR.positionCount];
        lR.GetPositions(shiftedPositions);
        for (int i = 0; i < shiftedPositions.Length; i++)
        {
            shiftedPositions[i].z = myCanvas.transform.position.z + 5;
        }
        this.gameObject.GetComponent<LineRenderer>().SetPositions(shiftedPositions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
