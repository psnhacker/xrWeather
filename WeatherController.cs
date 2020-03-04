using XrCore;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(GameTime))]
public class WeatherController : MonoBehaviour
{
    public Weather[] weathers;
    public Light sun;
    [Range(0f, 1f)]
    [SerializeField] private float progress = 0f;
    public float speed = 1f;
    private int counter = 0;
    private bool start = true; // Первый запуск
    private int nextCounter = 0;
    private AudioSource audioManager;
    private Env_ambient env;
    public GameTime timerEvent;

    private void Awake()
    {
        start = true;
        audioManager = GetComponent<AudioSource>();
        audioManager.playOnAwake = false;
        if (timerEvent == null) timerEvent = GetComponent<GameTime>();
        timerEvent.TimeBecome += StartAsyncWeather;
        timerEvent.SetWeather += StartAsyncWeather;
    }
    public void StartAsyncWeather()
    {
        StartCoroutine(AsyncWeather());
        StartCoroutine(RndSound());
    }

    IEnumerator AsyncWeather()
    {
        {
            counter = (int)DataTime.hour;
            int currenrWeather = counter;
            int nextWeather = counter;
            nextWeather = nextWeather + 1;
            if (nextWeather == weathers.Length) nextWeather = 0;
            nextCounter = nextWeather; //
            yield return null;
            if (start)
            {
                Material sky = new Material(Shader.Find("X-Ray Plugin/Skybox PRO"));
                sky.SetFloat("_BlendCubemaps", 0f);
                sky.SetTexture("_Tex", weathers[currenrWeather].Sky_Texture);
                sky.SetTexture("_Tex2", weathers[nextWeather].Sky_Texture);
                sky.SetFloat("_BlendFog", 0f);
                sky.SetColor("_FogStartColor", weathers[currenrWeather].Fog_color);
                sky.SetColor("_FogEndColor", weathers[nextWeather].Fog_color);
                RenderSettings.skybox = sky;
                start = false;
                yield return null;
            }
            if (weathers[currenrWeather].Env_ambient != null)
            {
                env = weathers[currenrWeather].Env_ambient;
                RndSound();
            }
            RenderSettings.skybox.SetFloat("_BlendCubemaps", 0f);
            RenderSettings.skybox.SetTexture("_Tex", weathers[currenrWeather].Sky_Texture);
            RenderSettings.skybox.SetTexture("_Tex2", weathers[nextWeather].Sky_Texture);
            RenderSettings.skybox.SetFloat("_BlendFog", 0f);
            RenderSettings.skybox.SetColor("_FogStartColor", weathers[currenrWeather].Fog_color);
            RenderSettings.skybox.SetColor("_FogEndColor", weathers[nextWeather].Fog_color);
            Color fog = weathers[currenrWeather].Fog_color;
            Color nextFogColor = weathers[nextWeather].Fog_color;
            Color skyColor = weathers[currenrWeather].Sky_color;
            Color nextSkyColor = weathers[nextWeather].Sky_color;
            yield return null;
            Color sunStart = weathers[currenrWeather].Hemi_color;
            Color sunEnd = weathers[nextWeather].Hemi_color;
            yield return null;
            while (progress < 1)
            {
                progress += 0.001f * speed;
                RenderSettings.ambientLight = Color.Lerp(weathers[currenrWeather].Ambient, weathers[nextWeather].Ambient, progress);
                RenderSettings.fogColor = Color.Lerp(fog, nextFogColor, progress);
                RenderSettings.skybox.SetFloat("_BlendFog", progress);
                RenderSettings.skybox.SetFloat("_BlendCubemaps", progress);
                yield return null;
                sun.color = Color.Lerp(sunStart, sunEnd, progress);
            }
            RenderSettings.skybox.SetFloat("_BlendFog", 1f);
            RenderSettings.skybox.SetFloat("_BlendCubemaps", 1f);
            sun.color = sunEnd;
            yield return null;
            progress = 0f;
            //StartCoroutine(WeatherManager());
        }
    }

    IEnumerator WeatherManager()
    {
        counter++;
        if (counter == weathers.Length) counter = 0;
        progress = 0f;
        yield return null;
        StartCoroutine(AsyncWeather());
    }

    IEnumerator RndSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            audioManager.volume = Random.Range(0.25f, 0.5f);
            audioManager.panStereo = Random.Range(-1f, 1f);
            audioManager.PlayOneShot(env.Sound_effects[Random.Range(0, env.Sound_effects.Count)]);
        }
    }
}

