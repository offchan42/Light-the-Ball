using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneLoaderLib : MonoBehaviour
    {
        public int buildIndex;

        public void LoadNow()
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}
