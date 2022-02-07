using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//invoker
public class CommandSystem : MonoBehaviour
{
    private List<ICommand> allUsedCommand;
    
    

    public void execute(ICommand input)
    {
        allUsedCommand.Add(input);
        input.execute();
    }

    public void undo()
    {
        if (allUsedCommand.Count == 0)
            return;

        allUsedCommand[allUsedCommand.Count - 1].undo();
        allUsedCommand.RemoveAt(allUsedCommand.Count - 1);

    }
}
