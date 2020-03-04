using UnityEngine;

[CreateAssetMenu(menuName = "X-Ray Engine/Weather/Weather cicle")]
public class Weather : ScriptableObject
{
    [Tooltip("Текстура неба")]
    [SerializeField] private Cubemap sky_texture;
    public Cubemap Sky_Texture
    {
        get { return sky_texture; }
        protected set { }
    }
    [Tooltip("Вращение неба")]
    [SerializeField] private float sky_rotation;
    public float Sky_Rotation
    {
        get { return sky_rotation; }
        protected set { }
    }
    [Tooltip("Цвет неба")]
    [SerializeField] private Color sky_color;
    public Color Sky_color
    {
        get { return sky_color; }
        protected set { }
    }
    [Tooltip("Цвет тумана")]
    [SerializeField] private Color fog_color;
    public Color Fog_color
    {
        get { return fog_color; }
        protected set { }
    }
    [Tooltip("Интенсивность дождя")]
    [Range(0f, 1f)]
    [SerializeField] private float rain_density;
    public float Rain_density
    {
        get { return rain_density; }
        protected set { }
    }
    [Tooltip("Цвет капель")]
    [SerializeField] private Color rain_color;
    public Color Rain_color
    {
        get { return rain_color; }
        protected set { }
    }
    [Tooltip("Гром")]
    [SerializeField] private Thunderbolt thunderbolt;
    public Thunderbolt Thunderbolt
    {
        get { return thunderbolt; }
        protected set { }
    }
    [Tooltip("Время между раскатами")]
    [SerializeField] private float bolt_period;
    public float Bolt_period
    {
        get { return bolt_period; }
        protected set { }
    }
    [Tooltip("Интенсивность грома")]
    [SerializeField] private float bolt_duration;
    public float Bolt_duration
    {
        get { return bolt_duration; }
        protected set { }
    }
    [Tooltip("Свет Ambient Color")]
    [SerializeField] private Color ambient;
    public Color Ambient
    {
        get { return ambient; }
        protected set { }
    }
    [Tooltip("Цвет лайтмап")]
    [SerializeField] private Color hemi_color;
    public Color Hemi_color
    {
        get { return hemi_color; }
        protected set { }
    }
    [Tooltip("Поворот солнца")]
    [SerializeField] private float sun_dir;
    public float Sun_dir
    {
        get { return sun_dir; }
        protected set { }
    }
    [Tooltip("Класс погоды")]
    [SerializeField] private Env_ambient env_ambient;
    public Env_ambient Env_ambient
    {
        get { return env_ambient; }
        protected set { }
    }
    public void SetSettings()
    {
        Debug.Log("Set Settings");
    }
}

[CreateAssetMenu(menuName = "X-Ray Engine/Weather/Weather Preset")]
public class WeatherConteiner : ScriptableObject
{
    [Tooltip("Настроенная погода")]
    [SerializeField] private Weather[] weathers;
    public Weather[] WeatherCollections
    {
        get { return weathers; }
        protected set { }
    }
}
