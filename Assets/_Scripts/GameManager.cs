using UnityEngine;
using ShaneClareDev;

public class GameManager : MonoBehaviour
{
    // text file containing level data
    public TextAsset levelDataTextFile;
    public AIPathFollower aIPathFollower;

    private Maze maze;

    void Awake()
    {
        LoadMapFromTextfile mapLoader = new LoadMapFromTextfile(levelDataTextFile);
        maze = mapLoader.GetMaze();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
