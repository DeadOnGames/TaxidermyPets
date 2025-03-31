using System.Collections.Generic;
using System;

[Serializable]
public class LevelData
{
    public int levelNumber;
    public List<string> animalIds;
}

[Serializable]
public class GameDatabase
{
    public List<AnimalData> allAnimals = new List<AnimalData>();
    public List<LevelData> allLevels = new List<LevelData>();
}

[Serializable]
public class AnimalListWrapper
{
    public List<AnimalData> animals;
}
