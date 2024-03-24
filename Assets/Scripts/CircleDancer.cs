using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDancer : MonoBehaviour
{
    public float radius = 5;
    public int count;
    public GameObject prefab;
    public float rotateSpeed = 100;
    public float sensitivity;
    public float boost = 2;
    public bool changeSize;

    private void Start()
    {
        for (float i = 0; i < count; i++)
        {
            var angle = i / count * Mathf.PI * 2;
            var pos = new Vector3();
            pos.x = Mathf.Cos(angle);
            pos.y = Mathf.Sin(angle);
            pos *= radius;

            var obj = Instantiate(prefab, pos, Quaternion.identity, transform);
            obj.transform.LookAt(transform);
        }

        Analyzer.onVolumeChanged.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        volume *= boost;
        transform.Rotate(0, 0, Mathf.Pow(volume, sensitivity) * rotateSpeed * Time.deltaTime);

        if (changeSize == false) return;
        transform.localScale = Vector3.one *(0.2f + volume);
    }
}
