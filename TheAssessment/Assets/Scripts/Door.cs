using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AnimationCurve openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) });
    public float openSpeedMultiplier = 2.0f;
    public float doorOpenAngle = 90.0f;

    [HideInInspector]
    public bool open = false;

    bool enter = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;

    public AudioClip audioClip;

    private GameObject player;

    [SerializeField] private DoorType doorType;

    public enum DoorType
    {
        Red,
        Green,
        Blue,
        Null
    }

    public DoorType GetDoorType()
    {
        return doorType;
    }

    private void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;

        // Set Collider as trigger in script so I can slap this script onto a door and not have to adjust in inspector
        GetComponent<Collider>().isTrigger = true;

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Main functionality
    private void Update()
    {
        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeedMultiplier * openSpeedCurve.Evaluate(openTime);
        }

        // The syntax for ?: (the ternary conditional operator) is as follows: condition ? consequent: alternative
        // The condition is a boolean expression, if true, the consequent is evaluated. If false, the alternative
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);

        // If the player presses F and is within the trigger that allows them to enter
        if (Input.GetKeyDown(KeyCode.F) && enter)
        {
            open = !open;
            currentRotationAngle = transform.localEulerAngles.y;
            openTime = 0;
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }

    // Activate the Main function when player enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        // When the collider on this object hits the player, you are allowed to open the door
        if (other.CompareTag("Player"))
        {
            KeyHolder keyHolder = player.GetComponent<KeyHolder>();
            if ((keyHolder.keyList.Contains(Key.KeyType.Red)) && doorType.Equals(DoorType.Red))
            {

                Debug.Log("You have entered the door trigger area");
                enter = true;
            }
            if ((keyHolder.keyList.Contains(Key.KeyType.Green)) && doorType.Equals(DoorType.Green))
            {

                Debug.Log("You have entered the door trigger area");
                enter = true;
            }
            if ((keyHolder.keyList.Contains(Key.KeyType.Blue)) && doorType.Equals(DoorType.Blue))
            {

                Debug.Log("You have entered the door trigger area");
                enter = true;
            }
            if (doorType.Equals(DoorType.Null))
            {
                Debug.Log("You have entered the door trigger area");
                enter = true;
            }
        }
    }

    // Deactivate the Main Function when Player exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You have left the door trigger area");
            enter = false;
        }
    }
}
