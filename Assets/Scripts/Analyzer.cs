using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Analyzer : MonoBehaviour
{
    AudioSource source;
    public UnityEvent<float> onVolumeChanged;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        var samples = new float[735];
        source.clip.GetData(samples, source.timeSamples);

        var sum = 0f;
        foreach (var sample in samples)
        {
            sum += Mathf.Abs(sample);
        }

        var average = sum / samples.Length;

        onVolumeChanged.Invoke(average);
    }
}
