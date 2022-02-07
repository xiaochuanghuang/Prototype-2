using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//concrete command
public class MoveCommand : ICommand
{
    private int[,] lastStep;
    private Gameplay gp;
    private Movement m;
    public MoveCommand(Gameplay gp, Movement m)
    {
        this.gp = gp;
        this.m = m;
        lastStep = gp.space;
    }
    public void execute()
    {
        gp.Move(m);

    }

    public void undo()
    {
       
    }
}
