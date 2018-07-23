using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{


    GameObject timerText;
    GameObject pointText;
    float time = 30.0f;
    int point = 0;
    GameObject generator;

    public void GetApple()
    {
        if (this.point < 1000)
            this.point += 100;
        else if (1000 <= this.point && this.point < 2000)
            this.point += 200;
        else if (2000<= this.point &&this.point < 4500)
            this.point += 300;
        else if (4500 <= this.point && this.point < 7000)
            this.point += 400;
        else if (7000 <= this.point && this.point < 10000)
            this.point += 500;


    }

    public void GetBomb()
    {
        if (this.point < 1000)
            this.point /= 2;
        else if (1000 <= this.point && this.point < 2000)
            this.point /= 3;
        else if (2000 <= this.point && this.point < 4500)
            this.point /= 4;
        else if (4500 <= this.point && this.point < 7000)
            this.point /= 5;
        else if (7000 <= this.point && this.point < 10000)
            this.point /= 6;
    }
    public void GetGApple()
    {
        this.point += 1200;
    }

    // Use this for initialization
    void Start()
    {
        this.generator = GameObject.Find("itemGeterator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParametor(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 5)
        {
            this.generator.GetComponent<ItemGenerator>().SetParametor(0.9f, -0.04f, 3);
        }
        else if (5 <= this.time && this.time < 10)
        {
            this.generator.GetComponent<ItemGenerator>().SetParametor(0.4f, -0.06f, 6);
        }
        else if (10 <= this.time && this.time < 20)
        {
            this.generator.GetComponent<ItemGenerator>().SetParametor(0.7f, -0.04f, 4);
        }
        else if (20 <= this.time && this.time < 30)
        {
            this.generator.GetComponent<ItemGenerator>().SetParametor(1.0f, -0.03f, 2);
        }
        
        this.timerText.GetComponent<Text>().text =
            this.time.ToString("F1");
        this.pointText.GetComponent<Text>().text =
            this.point.ToString() + " point";
    }
}
