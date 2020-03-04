using UnityEngine;
using System;
using XrCore;

public class GameTime : MonoBehaviour
{
    public float min;
    public float hour;
    public float day;
    public float speed = 1f;

    public Action TimeBecome;
    public Action SetWeather;

    private void Start()
    {
        SetWeather?.Invoke();
    }

    private void Update()
    {
        min += (Time.deltaTime / 6f) * speed;
        if (min >= 60f)
        {
            min = 0f;
            hour++;
            DataTime.hour = hour;
            TimeBecome?.Invoke();
            LocationMusic.Instance.PlaySound();
        }
        if (hour >= 24f)
        {
            hour = 0f;
            day++;
        }
    }
}


