using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameController : MonoBehaviour
{
    private Gameplay gameplay;
    private GameAssets[,] assetsArr;
    private CommandSystem cs;


    // Start is called before the first frame update
    void Start()
    {
        gameplay = new Gameplay();
        assetsArr = new GameAssets[4, 4];
        cs = GetComponent<CommandSystem>();
       
        initialize();
        for (int i = 0; i < 2; i++)
        {
            generateNumber();
        }

    }

    // connect the number and image, render them
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

    // generate sprite 
    private GameAssets generateSprite(int row, int col)
    {
        GameObject g = new GameObject(row.ToString() + col.ToString());

        g.AddComponent<Image>();
        GameAssets assets = g.AddComponent<GameAssets>();
        assets.setNewImage(0);
        g.transform.SetParent(this.transform,false);
        return assets;
    }
    // keeping tracking and updating the map in the screen
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

    //Spawn new number and adding the image for it
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
            if(gameplay.canSpawn)
            {
                generateNumber();
            }
            else
            {
                gameplay.canSpawn = true;
            }
        }
        gameplay.checking = false;
      
    }

    // Keyboard Control
    public void getInput()
    {
        
        if (Input.GetKeyDown(KeyCode.W))

        {
            MoveCommand mc = new MoveCommand(gameplay,Movement.Up);
            cs.execute(mc);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveCommand mc = new MoveCommand(gameplay, Movement.Down);
            cs.execute(mc);
        }
        if (Input.GetKeyDown(KeyCode.A))
   
        {
            MoveCommand mc = new MoveCommand(gameplay, Movement.Left);
            cs.execute(mc);
        }
        if (Input.GetKeyDown(KeyCode.D))
   
        {
            MoveCommand mc = new MoveCommand(gameplay, Movement.Right);
            cs.execute(mc);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            cs.undo();
        }

    }
 
}
