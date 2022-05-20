using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    private Color[] Colors = new Color[11] 
    {
        /// <summary>Black</summary>
        new Color(0f, 0f, 0f),
        /// <summary>Red</summary>
        new Color(1, 0f, 0f),
        /// <summary>Orange</summary>
        new Color(1f, 0.5f, 0f),
        /// <summary>Yellow</summary>
        new Color(1f, 1f, 0f),
        /// <summary>Green</summary>
        new Color(0f, 1f, 0f),
        /// <summary>Cyan</summary>
        new Color(0f, 1f, 1f),
        /// <summary>Blue</summary>
        new Color(0f, 0f, 1f),
        /// <summary>Purple</summary>
        new Color(1f, 0f, 1f),
        /// <summary>Pink</summary>
        new Color(1f, 0.5f, 1f),
        /// <summary>Black</summary>
        new Color(0f, 0f, 0f),
        /// <summary>White</summary>
        new Color(1f, 1f, 1f),
    };

    public void Colour—hange(int NumberColor) 
    {
        if (NumberColor < 0 || NumberColor >= Colors.Length) 
        {
            sprite.color = new Color(1f, 1f, 1f, 0.7f);
        }
        else
        {
            sprite.color = Colors[NumberColor];
        }

    }
}
