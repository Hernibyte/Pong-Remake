using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    #region Singleton
    public static GameConfig Get { get; private set; }
    #endregion

    public GameMode gameMode;

    private void Awake()
    {
        #region Singleton

        if (Get != null)
            Destroy(gameObject);
        Get = this;

        DontDestroyOnLoad(gameObject);

        #endregion
    }
}
