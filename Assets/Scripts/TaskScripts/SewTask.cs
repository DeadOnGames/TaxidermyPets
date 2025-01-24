using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SewTask : BaseTask
{
    
    public SewTask(GameObject canvas, UnityEvent onEndTask) : base(canvas, onEndTask)
    {
        
    }

    public override void BeginTask()
    {
        base.BeginTask();
        //All buttons are unchecked
    }

    public override void EndTask()
    {
        //when all buttons pressed
        base.EndTask();
    }
}
