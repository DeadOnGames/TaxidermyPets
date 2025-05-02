using UnityEngine;
using UnityEngine.Events;


public abstract class BaseTask : ITask
{
    private GameManager gameManager;

    protected UnityEvent onStartTask;
    protected UnityEvent onEndTask;

    protected GameObject canvas;
    protected GameObject Animal
    {
        get
        {
            if (gameManager == null)
            {
                gameManager = GameManager.Instance;
            }

            //TODO: Instead get from station manager
            //return gameManager?.currentAnimal;
            return null;
        }
    }

    public BaseTask(GameObject canvas, UnityEvent onStartTask, UnityEvent onEndTask)
    {
        gameManager = GameManager.Instance;
        this.canvas = canvas;
        this.onStartTask = onStartTask;
        this.onEndTask = onEndTask;
    }

    public virtual void BeginTask()
    {
        if (canvas != null)
            canvas.SetActive(true);

        Animal.GetComponent<Draggable>().IsDraggable = false;
        onStartTask?.Invoke();
    }

    public virtual void EndTask()
    {
        if (canvas != null)
            canvas.SetActive(false);

        if(Animal) Animal.GetComponent<Draggable>().IsDraggable = true;

        Debug.Log("EndTask has been invoked");
        onEndTask?.Invoke();
    }
}
