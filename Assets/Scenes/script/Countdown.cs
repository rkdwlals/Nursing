using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Countdown : MonoBehaviour
{
    int Count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
        // Update is called once per frame
    void Update()
    {
          if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(2)) //좌클릭 우클릭 감지해서 카운트
          {
              Count++;
              if (Count == 30)
              { 
                SceneManager.LoadScene("Load1");
              }
          }
    }
}

