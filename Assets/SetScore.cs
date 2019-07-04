using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    SaveThroughGame saveScript;

    private void Awake()
    {
        saveScript = FindObjectOfType<SaveThroughGame>();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "Score: " + saveScript.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = "Score: " + saveScript.score.ToString();
    }
}
