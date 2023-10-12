using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string playerName;
    private SpriteRenderer spriteRenderer;
    Color color;

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }

    public string GetName()
    {
        return playerName;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }
}
