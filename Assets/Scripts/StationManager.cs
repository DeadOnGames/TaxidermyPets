using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    List<Queue> queues = new List<Queue>();
    Queue station1_AnimalQueue = new Queue();
    Queue station2_AnimalQueue = new Queue();
    Queue station3_AnimalQueue = new Queue();

    public enum StationNumber
    {
        Station1 = 0,
        Station2 = 1,
        Station3 = 2
    }

    // Start is called before the first frame update
    void Start()
    {
        //Add queues to list
        queues.Add(station1_AnimalQueue);
        queues.Add(station2_AnimalQueue);   
        queues.Add(station3_AnimalQueue);
    }

    //Keep a record of what animal is currently in each station
    public object GetCurrentAnimalAtStation(StationNumber stationNumber)
    {
        switch(stationNumber)
        {
            case StationNumber.Station1:
                return station1_AnimalQueue.Peek();

            case StationNumber.Station2:
                return station2_AnimalQueue.Peek();

            case StationNumber.Station3:
                return station3_AnimalQueue.Peek();
            default:
                return null;
        }
    }
    
    public void ClearAllQueues()
    {
        foreach(Queue animalQueue in queues)
        {
            animalQueue.Clear();
        }
    }

    public void AddAnimalToQueue(StationNumber stationNumber, int id)
    {
        switch (stationNumber)
        {
            case StationNumber.Station1:
                station1_AnimalQueue.Enqueue(id);
                break;
            case StationNumber.Station2:
                station2_AnimalQueue.Enqueue(id);
                break;
            case StationNumber.Station3:
                station3_AnimalQueue.Enqueue(id);
                break;
            default:
                break;
        }

    }

    public void MoveAnimalToNextStationQueue(StationNumber stationNumber)
    {
        object tempAnimal; 

        switch (stationNumber)
        {
            case StationNumber.Station1:
                tempAnimal = station1_AnimalQueue.Dequeue();
                station2_AnimalQueue.Enqueue(tempAnimal);
                break;
            case StationNumber.Station2:
                tempAnimal = station2_AnimalQueue.Dequeue();
                station3_AnimalQueue.Enqueue(tempAnimal);
                break;
            case StationNumber.Station3:
                station3_AnimalQueue.Dequeue();
                break;
            default:
                break;
        }
    }
}
