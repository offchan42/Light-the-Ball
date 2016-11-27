using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelTextSetter : MonoBehaviour
    {
        public Text text;
        public int level = -1;

        void Awake()
        {
            if (level == -1)
            {
                level = SceneManager.GetActiveScene().buildIndex;
            }
            text.text = string.Format(text.text, level);
        }
    }
}