using System.Collections;
using System.Collections.Generic;

using UnityEngine;
    using UnityEngine.SceneManagement;

public class LoopManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject apartmentPrefab;

    private GameObject player;
    private Camera playerCamera;

    private GameObject temp;
    Animation anim;

    bool alreadyCreatedNewLoop;

    void Start()
    {
        alreadyCreatedNewLoop = false;

        apartmentPrefab = Resources.Load("Prefabs/Apartment") as GameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        player = other.transform.parent.gameObject;
        playerCamera = player.GetComponentInChildren<Camera>();

        anim = this.player.GetComponent<Animation>();
    }

    void OnTriggerStay(Collider other)
    {
        if (player.GetComponent<CameraMovement>().checkYawPitch(this.transform, out float angleY, out float angleX) && !anim.isPlaying)
        {
            if (!alreadyCreatedNewLoop)
            {
                alreadyCreatedNewLoop = true;

                GameObject nextApartment = Instantiate(apartmentPrefab, GameObject.Find("EndPoint").transform.position, Quaternion.identity);

                LoopCounter.LoopNumber++;
                int nextLoopNumber = LoopCounter.LoopNumber;

                nextApartment.name = "ApartmentLoop" + (nextLoopNumber);

                GameObject nextLevelHallway = GameObject.Find(nextApartment.name + "/Hallway");

                GameObject nextLevelDoorSystem = GameObject.Find("NextLevelDoorSystem");
                nextLevelDoorSystem.transform.parent = nextLevelHallway.transform;
                nextLevelDoorSystem.transform.localRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));

                GameObject.Find("NextLevelDoorFrame").transform.parent = nextLevelHallway.transform;

                switch (nextLoopNumber)
                {
                    case 1:
                        Loop1Creation(nextApartment);
                        break;

                    case 2:
                        Loop2Creation(nextApartment);
                        break;

                    case 5:
                        Cursor.lockState = CursorLockMode.None;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;

                    default:
                        break;

                }

            }

            GameObject.Find("NextLevelDoor").GetComponent<Animator>().SetBool("open", true);
            player.GetComponent<Movement>().playerCurrentState = Movement.playerState.ANGLEADJUSTING;

            temp = new GameObject("Temp");
            temp.transform.position = this.player.transform.position;
            temp.transform.rotation = this.transform.rotation;

            player.transform.SetParent(temp.transform);

            anim.Play();
        }
    }


    void Loop1Creation(GameObject nextApartment)
    {
        Debug.Log(nextApartment);
        // SPAWN GIRL
        Vector3 position = nextApartment.transform.position + new Vector3(-2.73f, -2.71f, 11.16f);
        Vector3 rotation = new Vector3(0f, -180f, -15f);

        SpawnGirl(position, rotation);
    }

    void Loop2Creation(GameObject nextApartment)
    {
        // SPAWN GIRL
        Vector3 position = nextApartment.transform.position + new Vector3(-4.79f, -3.043f, 0.95f);
        Vector3 rotation = new Vector3(0f, -180f, 0f);

        SpawnGirl(position, rotation);
    }

    static public void SpawnGirl(Vector3 pos, Vector3 rot)
    {
        GameObject silhouettePrefab = Resources.Load("Prefabs/Silhouette") as GameObject;
        GameObject sillhouetteLoop1 = Instantiate(silhouettePrefab, pos, Quaternion.Euler(rot));
    }
}
