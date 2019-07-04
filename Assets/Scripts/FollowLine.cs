using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowLine : MonoBehaviour
{
    private GameObject camera;
    private GameObject canvas;
    private List<float> diff;
    private GameObject line;
    private Vector3[] linePoints;
    private GameObject movingLight;
    private GameObject userLight;
    private SaveThroughGame saveScript;
    public float timer;
    private float timeInterval;
    // Start is called before the first frame update
    void Start()
    {
        this.timer = 20f;
        this.diff = new List<float>();
        this.camera = GameObject.FindGameObjectWithTag("MainCamera");
        this.canvas = GameObject.FindGameObjectWithTag("Canvas");
        this.line = GameObject.FindGameObjectWithTag("Line");
        this.userLight = GameObject.FindGameObjectWithTag("UserLight");
        saveScript = FindObjectOfType<SaveThroughGame>();
        LineRenderer oldLine = GameObject.FindGameObjectWithTag("Line").GetComponent<LineRenderer>();
        this.linePoints = new Vector3[oldLine.positionCount];
        //float scaleX = line.transform.transform.localScale.x;
        //float scaleY = line.transform.transform.localScale.y;
        //for (int i = 0; i < this.linePoints.Length; i++)
        //{
            //Vector3 p = this.linePoints[i];
            //this.linePoints[i] = this.canvas.transform.TransformPoint(new Vector3(p.x * scaleX * 1.07f, p.y * scaleY * 1.07f, p.z));
        //}
        oldLine.GetPositions(linePoints);
        this.movingLight = this.gameObject;
        //Debug.Log(this.linePoints.Length);
        this.timeInterval = this.timer / (float) this.linePoints.Length;
        Debug.Log(this.timeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        int arrayIndex = (int) (Time.timeSinceLevelLoad / this.timeInterval);
        Debug.Log(this.movingLight.transform.position);
        Debug.Log(this.userLight.transform.position);
        if (Time.timeSinceLevelLoad > .5 && arrayIndex < linePoints.Length)
        {
            this.diff.Add(Vector3.Magnitude(this.movingLight.transform.position - this.userLight.transform.position));
        }
        if (arrayIndex >= linePoints.Length)
        {
            float[] arr = this.diff.ToArray();
            float sum = 0;
            float avg;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            avg = sum / (float)arr.Length;
            saveScript.SetScore(avg);
            Debug.Log(avg);
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log(this.linePoints[arrayIndex]);
        Vector3 p = this.linePoints[Mathf.Min(arrayIndex, this.linePoints.Length - 1)];
        float scaleX = line.transform.transform.localScale.x;
        float scaleY = line.transform.transform.localScale.y;
        this.gameObject.transform.position = new Vector3(p.x * scaleX, p.y * scaleY, p.z) + line.transform.position ;
        //Vector3 pos = this.gameObject.transform.position;
        //this.gameObject.transform.position = p;
    }
}
