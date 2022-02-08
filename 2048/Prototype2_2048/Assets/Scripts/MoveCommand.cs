using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//concrete command
public class MoveCommand : ICommand
{
    private int[,] lastStep = new int[4,4];
    private Gameplay gp;
    private Movement m;
    public MoveCommand(Gameplay gp, Movement m)
    {

        this.gp = gp;
        this.m = m;
        //lastStep = gp.previous;
        Array.Copy(gp.space, lastStep, gp.space.Length);
    }
    public void execute()
    {
        if (gp.space != gp.previous)
        {
            gp.Move(m);
        }
       

    } 

    public void undo()
    {
        Array.Copy(lastStep, gp.space, gp.space.Length);
        gp.canSpawn = false;
        gp.checking = true;
        gp.previous = new int[4, 4];
        gp.Compare();
    }
}
