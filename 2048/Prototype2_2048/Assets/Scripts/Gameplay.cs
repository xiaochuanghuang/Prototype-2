using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
public struct EmptySpace
{
   public int rowPosition { get; set; }
   public int colPosition { get; set; }

    public EmptySpace(int row, int col) : this()
    {
        this.colPosition = col;
        this.rowPosition = row;
    }
}

public class Gameplay 
{
    //List for holding Empty Space
    List<EmptySpace> emptySpaceList;
    //Map
    private int[,] space;
    //Combine the array element
    private int[] combineArray;
    // Remove the zero element
    private int[] RemoveEmptyElement;
    //random number 
    private Random random;
    //Previous map
    private int[,] previous;

    //Check for game status
    public bool checking { get; set; }

   public enum Movement
    {
        Up,
        Down,
        Left,
        Right
    }

  
    public Gameplay()
    {
        //initial
        space = new int[4, 4];
        previous = new int[4, 4];
        combineArray = new int[4];
        RemoveEmptyElement = new int[4];
        emptySpaceList = new List<EmptySpace>(16);
        random = new Random();
    }

    private void GoUp()
    {
        for (int col = 0; col < 4; col++)
        {
            for (int row = 0; row <= 3; row++)
            {
                this.combineArray[row] = this.space[col, row];
            }
            Combined();

            for (int row = 0; row <= 3; row++)
            {
                this.space[row, col] = combineArray[row];
            }
        }
    }

    private void GoDown()
    {
        for (int col = 0; col < 4; col++)
        {
            for (int row = 3; row >= 0; row--)
            {
                this.combineArray[3 - row] = this.space[col, row];
            }
            Combined();

            for (int row = 3; row >= 0; row--)
            {
                this.space[row, col] = combineArray[3-row];
            }
        }
    }
    private void GoLeft()
    {
        for (int col = 0; col < 4; col++)
        {
            for (int row = 0; row <= 3; row++)
            {
                this.combineArray[row] = this.space[col, row];
            }
            Combined();

            for (int row = 0; row <= 3; row++)
            {
                this.space[col, row] = combineArray[row];
            }
        }

    }
    private void GoRight()
    {
        for(int col = 0; col < 4;col ++)
        {
            for(int row = 3; row >=0;row --)
            {
                this.combineArray[3 - row] = this.space[col, row];
            }
            Combined();

            for (int row = 3; row >= 0; row--)
            {
                this.space[col, row] = combineArray[3-row];
            }
        }
    }
    private void Combined()
    {
        removeZeroElement();

        for(int i = 0; i<combineArray.Length-1;i++)
        {
            if(combineArray[i] == combineArray[i+1])
            {
                combineArray[i] += combineArray[i + 1];
                combineArray[i + i] = 0;   
            }
        }
        removeZeroElement();
    }

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

    public void findingEmptySpace()
    {
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

    public void spawnNewNumber()
    {
        findingEmptySpace();

        if(emptySpaceList.Count > 0)
        {
            int index = random.Next(0, emptySpaceList.Count);
            EmptySpace position = emptySpaceList[index];
            space[position.rowPosition, position.colPosition]= random.Next(0, 10) == 1 ? 4 : 2;
            emptySpaceList.RemoveAt(index);
        }

    }

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

    public bool Gameover()
    {
        if(emptySpaceList.Count > 0 )
        {
            return false;
        }

        return true;
    }
}
