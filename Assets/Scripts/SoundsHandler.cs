using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip[] Sound;

    public void PlaySound(int Count = 0)
    {
        Debug.Log("PlaySound " + Sound[Count]);
        Source.PlayOneShot(Sound[Count]);
    }
}
