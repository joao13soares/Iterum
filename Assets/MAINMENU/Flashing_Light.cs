using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;

public class Flashing_Light : MonoBehaviour
{
    private Light light;
    private float timer, delay;
    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
        //timer = Random.Range(1f, 10f);

        //if (timer + Time.deltaTime > delay)


        if (timer >= delay)
        {
            timer = 0f;
            light.enabled = false;
            delay = Random.Range(0.1f, 2f);
            //StartCoroutine(dwd());
            //Thread.Sleep(Random.Range(250, 500));
             //new WaitForSeconds(5);
        }
        else
        {
            if (!light.enabled) light.enabled = true;
            //light.enabled = (!light.enabled) ? true : false;
            timer += Time.deltaTime;
        }
    }


    //IEnumerator dwd()
    //{
        
    //    yield return new WaitForSecondsRealtime(4);
    //}
}
