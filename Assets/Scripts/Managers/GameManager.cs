using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _GAME_MANAGER;

    private void Awake()
    {
        if (_GAME_MANAGER != null && _GAME_MANAGER != this)
        {
            Destroy(_GAME_MANAGER);
        }
        else
        {
            _GAME_MANAGER = this;
            DontDestroyOnLoad(_GAME_MANAGER);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
