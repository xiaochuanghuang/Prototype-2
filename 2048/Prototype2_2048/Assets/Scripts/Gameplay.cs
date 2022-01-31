using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EmptySpace
{
    int rowPosition { get; set; }
    int colPosition { get; set; }

    public EmptySpace(int row, int col) : this()
    {
        this.colPosition = col;
        this.rowPosition = row;
    }
}

public class Gameplay 
{
    //Map
    private int[,] space;
    //Combine the array element
    private int[] combineArray;
    // Remove the zero element
    private int[] RemoveEmptyElement;
   public enum Movement
    {
        Up,
        Down,
        Left,
        Right
    }

  
    public Gameplay()
    {
        space = new int[4, 4];
        combineArray = new int[4];
        RemoveEmptyElement = new int[4];
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

    }
}
