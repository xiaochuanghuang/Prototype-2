using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameController : MonoBehaviour
{
    private Gameplay gameplay;
    private GameAssets[,] assetsArr;

    // Start is called before the first frame update
    void Start()
    {
        gameplay = new Gameplay();
        assetsArr = new GameAssets[4, 4];
        initialize();
        for (int i = 0; i < 2; i++)
        {
            generateNumber();
        }

    }
    private void initialize()
    {
        for(int row = 0; row < 4; row++)
        {
            for(int col = 0; col < 4; col++)
            {
               assetsArr[row,col] =  generateSprite(row, col);
            }

        }
    }

    private GameAssets generateSprite(int row, int col)
    {
        GameObject g = new GameObject(row.ToString() + col.ToString());

        g.AddComponent<Image>();
        GameAssets assets = g.AddComponent<GameAssets>();
        assets.setNewImage(0);
        g.transform.SetParent(this.transform,false);
        return assets;
    }

    private void updating()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                assetsArr[row, col].setNewImage(gameplay.space[row,col]);
            }

        }
    }

    private void generateNumber()
    {
        EmptySpace? s;
        int? nums;
        gameplay.spawnNewNumber(out s, out nums);
        assetsArr[s.Value.rowPosition, s.Value.colPosition].setNewImage(nums.Value);

    }

    private void Update()
    {
   
        getInput();
        if (gameplay.checking)
        { 
            updating();
            generateNumber();
        }

        if(gameplay.Gameover())
        {

        }
        gameplay.checking = false;
      
    }

    private void getInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
            gameplay.Move(Movement.Up);
        if (Input.GetKeyDown(KeyCode.S))
            gameplay.Move(Movement.Down);
        if (Input.GetKeyDown(KeyCode.A))
            gameplay.Move(Movement.Left);
        if (Input.GetKeyDown(KeyCode.D))
            gameplay.Move(Movement.Right);

    }
 
}
