using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SmallGameManager : MonoBehaviour
{
    [SerializeField]
    Player[] players;

    [SerializeField]
    SmallGameUIManager UIManager;

    GameObject[,] cellGameObjects;
    string[,] grid;

    private Turn currentTurn;
    private bool gameWon;

    void Start()
    {
        currentTurn = (Turn)Random.Range(0, players.Length);
        grid = new string[,]
        {
            { "-", "-", "-" },
            { "-", "-", "-" },
            { "-", "-", "-" }
        };

        gameWon = false;
    }

    public void SetCellGrid(GameObject[,] grid)
    {
        cellGameObjects = grid;
    }

    enum Turn { X, O }

    public void PlayTurn(int buttonIndex)
    {
        if (gameWon)
            return;

        int row = buttonIndex / 3;
        int col = buttonIndex % 3;

        if (grid[row, col] == "-")
        {
            Player currentPlayer = players[(int)currentTurn];

            UIManager.UpdatePicture(currentPlayer, buttonIndex);

            grid[row, col] = currentPlayer.GetName();

            PrintGrid();

            currentTurn = (Turn)((int)(currentTurn + 1) % players.Length);

            gameWon = GameWon(currentPlayer);


            if (gameWon)
            {
                Debug.Log(currentPlayer.name + " won!!!");
            }
        }
    }

    private bool GameWon(Player currentPlayer)
    {
        string name = currentPlayer.GetName();

        for (int i = 0; i < 3; i++) 
        {
            //horizontal
            if (grid[i, 0] == name && grid[i, 1] == name && grid[i, 2] == name) return true;

            //vertical
            if (grid[0, i] == name && grid[1, i] == name && grid[2, i] == name) return true;

        }

        if (grid[0, 0] == name && grid[1, 1] == name && grid[2, 2] == name) return true;

        return grid[0, 2] == name && grid[1, 1] == name && grid[2, 0] == name;
    }


    private void PrintGrid()
    {
        string s = "";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                s += $"{grid[i, j]} ";
            }
            s += "\n";
        }

        Debug.Log(s);
    }
}
