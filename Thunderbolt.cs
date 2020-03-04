using UnityEngine;

[CreateAssetMenu(menuName = "X-Ray Engine/Weather/Thunderbolt")]
public class Thunderbolt : ScriptableObject
{
    [Tooltip("Префаб молнии")]
    [SerializeField] private GameObject lightning_model;
    public GameObject Lightning_model
    {
        get { return lightning_model; }
        protected set { }
    }
    [Tooltip("Звук эффекта")]
    [SerializeField] private AudioClip sound;
    public AudioClip Sound
    {
        get { return sound; }
        protected set { }
    }
    [Tooltip("Материал градиента")]
    [SerializeField] private Material gradient_center_texture;
    public Material Gradient_center_texture
    {
        get { return gradient_center_texture; }
        protected set { }
    }
}
