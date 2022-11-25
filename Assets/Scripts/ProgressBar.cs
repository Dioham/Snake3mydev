using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public SnakeMovement SnakeMovement;
    public Transform Finish;
    public Slider Slider;

    private float _startZ;
    private float minimumReachedZ;

    private void Start()
    {
        _startZ = SnakeMovement.transform.position.z;
    }

    private void Update()
    {
        minimumReachedZ = Mathf.Min(minimumReachedZ, SnakeMovement.transform.position.z);

        float finishZ = Finish.position.z;
        float t = Mathf.InverseLerp(_startZ, finishZ, minimumReachedZ);
        Slider.value = t;

    }
}
