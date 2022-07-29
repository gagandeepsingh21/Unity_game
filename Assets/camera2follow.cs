using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam1;
    public GameObject cam2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }

        }
    }
}
