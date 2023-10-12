using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SmallGameUIManager : MonoBehaviour
{
    [SerializeField]
    private SmallGameManager gameManager;

    [SerializeField]
    private GameObject tilePrefab;

    [SerializeField]
    private GameObject canvas;

    private GameObject[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[3, 3];
        for (int i = 0; i < 9; i++)
        {

            float gap = .05f; //the space between each cell
            float marginHor = .05f; //the amount of space on the horizontal sides of the canvas

            float size = (1 - (gap * 2) - (marginHor * 2)) / 3f; //the size each cell will be

            int row = i / 3;
            int col = i % 3;

            string name = i switch {
                0 => "Top Left",
                1 => "Top Middle",
                2 => "Top Right",
                3 => "Middle Left",
                4 => "Middle",
                5 => "Middle Right",
                6 => "Bottom Left",
                7 => "Bottom Middle",
                8 => "Bottom Right",
                _ => "Something is wrong"
            };

            GameObject obj = Instantiate(tilePrefab);
            obj.transform.SetParent(canvas.transform);
            obj.name = name;

            TextMeshProUGUI buttonText = obj.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
            buttonText.text = "";

            RectTransform transform = obj.GetComponent<RectTransform>();
            float minX = marginHor + col * size + (col * gap);
            float maxY = 1 - (row * size + (row * gap) + marginHor);
            transform.anchorMin = new Vector2(minX, maxY - size);
            transform.anchorMax = new Vector2(minX + size, maxY);
            transform.offsetMin = new Vector2(0, 0);
            transform.offsetMax = new Vector2(0, 0);

            grid[row, col] = obj;

            SetUpButton(obj, i);

        }
        gameManager.SetCellGrid(grid);

    }

    private void SetUpButton(GameObject obj, int index) 
    {
        Button b = obj.GetComponent<Button>();
        b.onClick.AddListener(() => { gameManager.PlayTurn(index); });
    }

    public void UpdatePicture(Player player, int buttonIndex)
    {
        UpdatePicture(player, buttonIndex / 3, buttonIndex % 3);
    }

    public void UpdatePicture(Player player, int row, int col)
    {
        Image img = grid[row, col].GetComponent<Image>();
        SpriteRenderer playerRenderer = player.GetSpriteRenderer();

        img.color = playerRenderer.color;
        img.sprite = playerRenderer.sprite;
    }
}
