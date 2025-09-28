using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumeController : MonoBehaviour
{

    private VolumeManager volumeManager;
    private AudioSource audioSource;
    [SerializeField] private float audioSourceMaxVolume = 1f;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject emittingObject;


    private void Awake()
    {
        volumeManager = FindObjectOfType<VolumeManager>();
        if (volumeManager == null)
        {
            Debug.LogWarning("Could not find Volume Manager!");
        }
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        volumeManager?.volumeControllers.Add(this);
        adjustVolume(volumeManager.getVolume());
    }

    private void OnDisable()
    {
        volumeManager?.volumeControllers.Remove(this);
    }

    /*
    void FixedUpdate()
    {
        if (cam != null && emittingObject != null) {
            float distance = cam.transform.position.x - emittingObject.transform.position.x;
            Debug.Log(distance);
            adjustVolume(getRelativeVolume(audioSource.volume) + distance);
        }
    }
    */

    /*public void Update()
    {
        if (IsInView(cam.)
        {
            
        }
    }

    private bool IsInView(GameObject origin, GameObject toCheck)
    {
        Vector3 pointOnScreen = cam.WorldToScreenPoint(toCheck.GetComponentInChildren<Renderer>().bounds.center);

        //Is in front
        if (pointOnScreen.z < 0)
        {
            Debug.Log("Behind: " + toCheck.name);
            return false;
        }

        //Is in FOV
        if ((pointOnScreen.x < 0) || (pointOnScreen.x > Screen.width) ||
                (pointOnScreen.y < 0) || (pointOnScreen.y > Screen.height))
        {
            Debug.Log("OutOfBounds: " + toCheck.name);
            return false;
        }

        RaycastHit hit;
        Vector3 heading = toCheck.transform.position - origin.transform.position;
        Vector3 direction = heading.normalized;// / heading.magnitude;

        if (Physics.Linecast(cam.transform.position, toCheck.GetComponentInChildren<Renderer>().bounds.center, out hit))
        {
            if (hit.transform.name != toCheck.name)
            {
                Debug.Log(toCheck.name + " occluded by " + hit.transform.name);
                return false;
            }
        }
        return true;
    }*/

    public void adjustVolume(float volume)
    {
        audioSource.volume = getRelativeVolume(volume);
    }

    private float getRelativeVolume(float input_volume)
    {
        return audioSourceMaxVolume * input_volume;
    }

    public void setMaxVolume(float new_max_volume)
    {
        audioSourceMaxVolume = new_max_volume;
        adjustVolume(volumeManager.getVolume());
    }
    public float getMaxVolume()
    {
        return audioSourceMaxVolume;
    }
}
