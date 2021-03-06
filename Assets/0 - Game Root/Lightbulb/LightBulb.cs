﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBulb : MonoBehaviour
{

    public Light lightSource;

    public Slider intensitySlider;
    public Slider rangeSlider;

    public void Start()
    {
        if(intensitySlider)
            intensitySlider.onValueChanged.AddListener(delegate { IntensityChangeCheck(); });
        if(rangeSlider)
            rangeSlider.onValueChanged.AddListener(delegate { RangeChangeCheck(); });
    }

    public void IntensityChangeCheck()
    {
        lightSource.intensity = intensitySlider.value * 2;
    }

    public void RangeChangeCheck()
    {
        lightSource.range = rangeSlider.value * 10;
    }
}
