using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBalanceBoard : MonoBehaviour
{
    Vector2 cob;
    SaveThroughGame stgScript;
    Vector3  linePos;
    // Start is called before the first frame update
    void Start()
    {
        stgScript = GameObject.FindGameObjectWithTag("Var").GetComponent<SaveThroughGame>();
        cob = stgScript.centerOfBalance;
        linePos = GameObject.FindGameObjectWithTag("Line").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2 = Wii.GetCenterOfBalance(0) - cob;
        float newX;
        float newY;
        float width = 350f;
        if (v2.x > 0f)
        {
            newX = Mathf.Abs(width / stgScript.maxX) * v2.x;
        } else
        {
            newX = Mathf.Abs(width / stgScript.minX) * v2.x;
        }

        if (v2.y > 0f)
        {
            newY = Mathf.Abs(175f / stgScript.maxY) * v2.y;
        } else
        {
            newY = Mathf.Abs(-175f / stgScript.minY) * v2.y;
        }

        Debug.Log(newX);
        Debug.Log(newY);
        this.gameObject.transform.position = new Vector3(newX, newY, 0f) + linePos;
        Debug.Log(this.gameObject.transform.position);
    }
}
