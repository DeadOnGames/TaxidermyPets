using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    private const int StationCount = 4;
    private readonly List<Queue> _queues = new List<Queue>(StationCount);

    private readonly Queue _station0AnimalQueue = new Queue();
    private readonly Queue _station1AnimalQueue = new Queue();
    private readonly Queue _station2AnimalQueue = new Queue();
    private readonly Queue _station3AnimalQueue = new Queue();

    public enum StationNumber
    {
        Station0 = 0,
        Station1 = 1,
        Station2 = 2,
        Station3 = 3
    }

    private void Start()
    {
        // Initialize queues list
        _queues.Add(_station0AnimalQueue);
        _queues.Add(_station1AnimalQueue);
        _queues.Add(_station2AnimalQueue);
        _queues.Add(_station3AnimalQueue);
    }

    public object GetCurrentAnimalAtStation(StationNumber stationNumber)
    {
        return GetStationQueue(stationNumber)?.Peek();
    }

    public void ClearAllQueues()
    {
        foreach (var animalQueue in _queues)
        {
            animalQueue.Clear();
        }
    }

    public void AddAnimalToQueue(StationNumber stationNumber, string id)
    {
        GetStationQueue(stationNumber)?.Enqueue(id);
    }

    public void MoveAnimalToNextStationQueue(StationNumber stationNumber)
    {
        var currentQueue = GetStationQueue(stationNumber);
        if (currentQueue == null || currentQueue.Count == 0) return;

        var tempAnimal = currentQueue.Dequeue();

        if (stationNumber != StationNumber.Station3)
        {
            GetStationQueue(stationNumber + 1)?.Enqueue(tempAnimal);
        }
    }

    private Queue GetStationQueue(StationNumber stationNumber)
    {
        switch (stationNumber)
        {
            case StationNumber.Station0: return _station0AnimalQueue;
            case StationNumber.Station1: return _station1AnimalQueue;
            case StationNumber.Station2: return _station2AnimalQueue;
            case StationNumber.Station3: return _station3AnimalQueue;
            default: return null;
        }
    }
}