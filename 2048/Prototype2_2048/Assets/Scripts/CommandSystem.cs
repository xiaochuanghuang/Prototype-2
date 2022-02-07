using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//invoker
public class CommandSystem : MonoBehaviour
{
    private List<ICommand> allUsedCommand;
    
    

    public void execute(ICommand input)
    {
        input.execute();
    }

    public void undo()
    {

    }
}
