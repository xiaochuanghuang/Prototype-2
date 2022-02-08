using System;
using System.Collections.Generic;
using Random = System.Random;
public struct EmptySpace
{
   public int rowPosition { get; set; }
   public int colPosition { get; set; }

    /*
     used to save the empty space
     */
    public EmptySpace(int row, int col) : this()
    {
        this.colPosition = col;
        this.rowPosition = row;
    }
}
public enum Movement
{
    Up,
    Down,
    Left,
    Right
}
public class Gameplay 
{
    //List for holding Empty Space
    List<EmptySpace> emptySpaceList;
    //Map
    public int[,] space;
    //Combine the array element
    private int[] combineArray;
    // Remove the zero element
    private int[] RemoveEmptyElement;
    //random number 
    private Random random;
    //Previous map
    public int[,] previous;

    //Check for game status
    public bool checking { get; set; }

    //can spawn new number
    public bool canSpawn { get; set; }

  
    public Gameplay()
    {
        //initial
        space = new int[4, 4];
        previous = new int[4, 4];
        combineArray = new int[4];
        RemoveEmptyElement = new int[4];
        emptySpaceList = new List<EmptySpace>(16);
        random = new Random();
        canSpawn = true;
    }

    private void GoUp()
    {
        for (int col = 0; col < 4; col++)
        {
            for (int row = 0; row <= 3; row++)
            {
                combineArray[row] = space[row, col];
            }
            Combined();

            for (int row = 0; row <= 3; row++)
            {
                space[row, col] = combineArray[row];
            }
        }
    }

    private void GoDown()
    {
        for (int col = 0; col < 4; col++)
        {
            for (int row = 3; row >= 0; row--)
            {
                combineArray[3 - row] = space[row, col];
            }
            Combined();

            for (int row = 3; row >= 0; row--)
            {
                space[row, col] = combineArray[3-row];
            }
        }
    }
    private void GoLeft()
    {
        for (int col = 0; col < 4; col++)
        {
            for (int row = 0; row <= 3; row++)
            {
                combineArray[row] = space[col, row];
            }
            Combined();

            for (int row = 0; row <= 3; row++)
            {
               space[col, row] = combineArray[row];
            }
        }

    }
    private void GoRight()
    {
        for(int col = 0; col < 4;col ++)
        {
            for(int row = 3; row >=0;row --)
            {
               combineArray[3 - row] = space[col, row];
            }
            Combined();

            for (int row = 3; row >= 0; row--)
            {
                space[col, row] = combineArray[3-row];
            }
        }
    }
    /*
     Combined two same number to new a new number
     */
    private void Combined()
    {
        removeZeroElement();
      
        for(int i = 0; i<combineArray.Length-1;i++)
        {
            if(combineArray[i] == combineArray[i+1])
            {
                combineArray[i] += combineArray[i + 1];
                combineArray[i + 1] = 0;   
            }
        }
        removeZeroElement();
    }

    /*
     Remove the zero element when number moves
     */
    private void removeZeroElement()
    {
        Array.Clear(RemoveEmptyElement, 0, 4);
        int number = 0;
        for(int i = 0; i < combineArray.Length;i++)
        {
            if(combineArray[i] != 0)
            {
                RemoveEmptyElement[number++] = combineArray[i];
            }
           
        }
        RemoveEmptyElement.CopyTo(combineArray, 0);
    }
    /*
     Using switch to control number movement 
     */
    public void Move(Movement d)
    {
        Array.Copy(space, previous, space.Length);
        checking = false;
        switch(d)
        {
            case Movement.Up:
                GoUp();
                break;
            case Movement.Down:
                GoDown();
                break;
            case Movement.Left:
                GoLeft();
                break;
            case Movement.Right:
                GoRight();
                break;
        }
        Compare();

    }

    /*
     Looking for the empty space
     */
    public void findingEmptySpace()
    {
        emptySpaceList.Clear();
        for(int row = 0; row < 4;row++)
        {
            for(int col = 0; col < 4; col++)
            {
                if(space[row,col] == 0)
                {
                    emptySpaceList.Add(new EmptySpace(row, col));
                }
            }
        }
    }
    // spawn new number in the empty area
    public void spawnNewNumber(out EmptySpace? s, out int? nums )
    {

        findingEmptySpace();
       if(emptySpaceList.Count == 0)
        {
            s = null;
            nums = null;
        }
        else
        {
            int index = random.Next(0, emptySpaceList.Count);
            s = emptySpaceList[index];
            nums = this.space[s.Value.rowPosition, s.Value.colPosition]
                 = random.Next(1, 11) == 1 ? 4 : 2;
            emptySpaceList.RemoveAt(index);
        }

    }

    //compare the map is changed or not to dected game state
    public void Compare()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                if (space[row, col] != previous[row,col] )
                {
                    checking = true;
                    return;
                }
            }
        }
    }

    // gameover check
    public bool Gameover()
    {
        if(emptySpaceList.Count > 0 )
        {
            return false;
        }

        return true;
    }
}
