using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;

public class mover : MonoBehaviour
{
    // Start is called before the first frame update
    int points = 0;
    public GameObject trashbin;
    public GameObject persons;
    public Color goodColor;
    public Color badColor;
    public Camera camera1;
    public Camera camera2;
    public TMP_Text myText;
    float Timer = 0.0f;
    public Rigidbody rb;
    

    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.transform.Translate(0f, 0f, 0.03f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Translate(0.03f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Translate(-0.03f, 0f, 0f);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            rb.transform.Translate(0f, 0f, -0.03f);
        }
        if (Input.GetKey("c"))
        {
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
        myTimer();
        if(points >= 30)
        {
            SceneManager.LoadScene("Scene2");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == trashbin)
        {
            points = points + 3;
            Vector3 InstOffset = new Vector3(0.5F, 0F, 0.5f);
            Vector3 newPost = trashbin.transform.position + InstOffset;
            Debug.Log("trashbin hit");
            var clone = Instantiate(trashbin, newPost, Quaternion.identity);
            Destroy(trashbin);
            //rb.GetComponent<Renderer>().material.color = goodColor;
            clone.name = "trashbin";
            trashbin = clone;

        }

        if (collision.gameObject == persons)
        {

            points = points - 2;
            Vector3 InstOffset = new Vector3(1F, 0F, 1f);
            Vector3 newPost = trashbin.transform.position + InstOffset;
            Debug.Log("persons hit");

            var pclone = Instantiate(trashbin, newPost, Quaternion.identity);
            Destroy(trashbin);
            //rb.GetComponent<Renderer>().material.color = badColor;
            pclone.name = "Persons";
            trashbin = pclone;
        }
    }

    public void myTimer()
    {
        Timer += Time.deltaTime;
        float seconds = Timer % 60;
        int secShort = (int)seconds;
        Debug.Log(secShort);
        myText.text = "Time:" +secShort.ToString() + "Seconds" + "\n\n" +"Score: " + points.ToString() + "points";
    }
}
