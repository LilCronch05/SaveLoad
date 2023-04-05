using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaManager : MonoBehaviour
{
    [SerializeField]
    Transform spawn;
    [SerializeField]
    string areaName;
    PlayerController player;
    bool transition = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = spawn.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.Fade(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController.Destination.transform.position = spawn.position;

        if (transition && !player.Fading())
        {
            SceneManager.LoadScene(areaName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(PlayerInfo.piInstance.currentScene);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerController>();
        player.Fade(true);
        transition = true;
    }
}
