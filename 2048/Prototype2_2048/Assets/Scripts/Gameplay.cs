using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    private void GoDown()
    {

    }
    private void GoLeft()
    {

    }
    private void GoRight()
    {

    }
    public void Move(Movement d)
    {
        switch(d)
        {
            case Movement.Up:
                break;
            case Movement.Down:
                break;
            case Movement.Left:
                break;
            case Movement.Right:
                break;
        }

    }
}
