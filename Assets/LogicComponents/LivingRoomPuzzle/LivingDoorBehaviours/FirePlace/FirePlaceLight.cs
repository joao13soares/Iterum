using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlaceLight : MonoBehaviour
{
    Light firePlaceLight;
    int sign;

    // Start is called before the first frame update
    void Start()
    {
        firePlaceLight = this.GetComponent<Light>();
        sign = -1;
    }

    // Update is called once per frame
    void Update()
    {
        firePlaceLight.intensity += sign * 0.1f;

        if (firePlaceLight.intensity < 1.5f || firePlaceLight.intensity > 2f)
        {
            sign *= -1;
        }
    }
}
