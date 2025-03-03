using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SewTask : BaseTask
{
    public SewTask(GameObject canvas, UnityEvent onStartTask, UnityEvent onEndTask) : base(canvas, onStartTask, onEndTask)
    {
        
    }

    public override void BeginTask()
    {
        base.BeginTask();
    }

    public override void EndTask()
    {
        base.EndTask();
    }
}
