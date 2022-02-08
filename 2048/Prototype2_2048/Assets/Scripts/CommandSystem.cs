using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//invoker
public class CommandSystem : MonoBehaviour
{
    private List<ICommand> allUsedCommand = new List<ICommand>();
    private Gameplay gp = new Gameplay();
    

    public void execute(ICommand input)
    {

       // if (gp.space) 
        allUsedCommand.Add(input);
        input.execute();


    }

    public void undo()
    {

        if (allUsedCommand.Count ==0 )
            return;

        allUsedCommand[allUsedCommand.Count - 1].undo();
        allUsedCommand.RemoveAt(allUsedCommand.Count - 1);

    }
}
