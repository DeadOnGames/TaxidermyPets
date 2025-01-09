using UnityEngine;

public abstract class BaseTask : ITask
{
    private GameManager gameManager;

    protected GameObject canvas;
    protected GameObject Animal
    {
        get
        {
            if (gameManager == null)
            {
                gameManager = GameManager.Instance;
            }

            return gameManager?.currentAnimal;
        }
    }

    public BaseTask(GameObject canvas)
    {
        gameManager = GameManager.Instance;
        this.canvas = canvas;
    }

    public virtual void BeginTask()
    {
        if (canvas != null)
            canvas.SetActive(true);

        Animal.GetComponent<Draggable>().IsDraggable = false;
    }

    public virtual void EndTask()
    {
        if (canvas != null)
            canvas.SetActive(false);

        if(Animal) Animal.GetComponent<Draggable>().IsDraggable = true;
    }
}
