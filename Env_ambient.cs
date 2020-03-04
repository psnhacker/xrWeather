using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "X-Ray Engine/Weather/env_ambient")]
public class Env_ambient : ScriptableObject
{
    [Tooltip("Список звуковых эффектов")]
    [SerializeField] private List<AudioClip> sound_effects = new List<AudioClip>();
    public List<AudioClip> Sound_effects
    {
        get { return sound_effects; }
        protected set { }
    }
    [Tooltip("Список звуковых эффектов")]
    [SerializeField] private string sound_list;
    public string Sound_list
    {
        get { return sound_list; }
        protected set { }
    }
    [Tooltip("Время между звуками")]
    [SerializeField] private Vector2 sound_period;
    public Vector2 Sound_period
    {
        get { return sound_period; }
        protected set { }
    }
    [Space]
    [Tooltip("Список природных эффектов")]
    [SerializeField] private List<AE_Effect> ae_effects = new List<AE_Effect>();
    public List<AE_Effect> Ae_effects
    {
        get { return ae_effects; }
        protected set { }
    }
    [Tooltip("Время между эффектами")]
    [SerializeField] private Vector2 effect_period;
    public Vector2 Effect_period
    {
        get { return effect_period; }
        protected set { }
    }

    public void SetSound()
    {
        if(sound_list.Length < 1)
        {
            Debug.Log("Строка пуста");
            return;
        }
        else
        {
            string[] clips = sound_list.Split(',');
            for (int i = 0; i < clips.Length; i++)
            {
                var path = clips[i];
                var currentClip = Resources.Load<AudioClip>("sounds/" + path);
                sound_effects.Add(currentClip);
            }
        }
    }
}

[CreateAssetMenu(menuName = "X-Ray Engine/Weather/env_ambient_effect")]
public class AE_Effect : ScriptableObject
{
    [Tooltip("Время действия эффекта")]
    [SerializeField] private float life_time;
    public float Life_time
    {
        get { return life_time; }
        protected set { }
    }
    [Tooltip("Система частиц эффекта")]
    [SerializeField] private ParticleSystem particles;
    public ParticleSystem Particles
    {
        get { return particles; }
        protected set { }
    }
    [Tooltip("Звук эффекта")]
    [SerializeField] private AudioClip sound;
    public AudioClip Sound
    {
        get { return sound; }
        protected set { }
    }
    [Tooltip("Смещение эффекта")]
    [SerializeField] private Vector3 offset;
    public Vector3 Offset
    {
        get { return offset; }
        protected set { }
    }
}
