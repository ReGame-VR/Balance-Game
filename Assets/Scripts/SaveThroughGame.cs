using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveThroughGame : MonoBehaviour
{
    public Vector2 centerOfBalance;
    public GameObject idInput;
    public string userId;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float score;
    public float timer;
    private InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>();
        DontDestroyOnLoad(this);
        centerOfBalance = Wii.GetCenterOfBalance(0);
        idInput = GameObject.FindGameObjectWithTag("InputText");
        timer = -100;
        maxX = 0;
        maxY = 0;
        minX = 0;
        minY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 reading = Wii.GetCenterOfBalance(0);
        //Calibrate Maximum Force on Wii Board
        if (Time.timeSinceLevelLoad - timer < 10)
        {
            if (reading.x - centerOfBalance.x > maxX)
            {
                maxX = reading.x - centerOfBalance.x;
            }
            if (reading.y - centerOfBalance.y > maxY)
            {
                maxY = reading.y - centerOfBalance.y;
            }
            if (reading.x - centerOfBalance.x < minX)
            {
                minX = reading.x - centerOfBalance.x;
            }
            if (reading.y - centerOfBalance.y < minY)
            {
                minY = reading.y - centerOfBalance.y;
            }
        }

        //Allow other methods of hitting buttons due to strange game interaction window
        if (Input.GetKey(KeyCode.Keypad0) && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("GameRunning");
        }
        if (Input.GetKey(KeyCode.Keypad1) && Input.GetKey(KeyCode.E)) {
            SetCenterOfBalance();
        }
        if (Input.GetKey(KeyCode.Keypad2) && Input.GetKey(KeyCode.E)) {
            SetMaximums();
        }
        if (Input.GetKey(KeyCode.Keypad3) && Input.GetKey(KeyCode.E))
        {
            EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
            inputField.OnPointerClick(new PointerEventData(EventSystem.current));
        }
        if (Input.GetKey(KeyCode.Keypad4) && Input.GetKey(KeyCode.E))
        {
            SetId();
        }

    }


    public void SetCenterOfBalance()
    {
        this.centerOfBalance = Wii.GetCenterOfBalance(0);
        Debug.Log(this.centerOfBalance);
    }

    public void SetId()
    {
        this.userId = idInput.GetComponent<Text>().text;
        Debug.Log(this.userId);
    }

    public void SetMaximums()
    {
        timer = Time.timeSinceLevelLoad;
    }

    public void SetScore(float val)
    {
        score = val;
    }
}
