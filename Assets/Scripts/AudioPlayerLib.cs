using UnityEngine;

namespace Assets.Scripts
{
    public class AudioPlayerLib : MonoBehaviour
    {
        public AudioSource audioSource;

        public void PlayNow()
        {
            audioSource.Play();
        }
    }
}