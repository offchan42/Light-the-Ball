using UnityEngine;

namespace Assets.Scripts
{
    public class InitSpriteRandomizer : MonoBehaviour
    {
        public Sprite[] candidateSprites;

        // Use this for initialization
        private void Start()
        {
            var index = Random.Range(0, candidateSprites.Length);
            var chosenSprite = candidateSprites[index];
            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                print("A SpriteRender component is required for InitSpriteRandomizer to be working correctly");
            }
            else
            {
                spriteRenderer.sprite = chosenSprite;
            }
        }
    }
}