using UnityEngine;

namespace Assets.Scripts
{
    public class BackgroundMusicLoader : MonoBehaviour
    {
        public AudioPlayerLib audioPlayerLib;

        private void Awake()
        {
            GameObject music = GameObject.Find("Background Music");
            if (music == null)
            {
                AudioPlayerLib playerLib = Instantiate(audioPlayerLib);
                playerLib.name = "Background Music";
                DontDestroyOnLoad(playerLib);
            }
        }
    }
}