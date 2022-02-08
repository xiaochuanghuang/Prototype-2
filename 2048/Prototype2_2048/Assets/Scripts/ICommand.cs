using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//command interface
public interface ICommand 
{
     void execute();

    void undo();
}
