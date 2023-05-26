using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeRaycast : MonoBehaviour
{
    public Transform raycastOrigin; // The GameObject created in step 1
    public float raycastDistance; // The maximum distance the raycast should travel
    public Sprite crossSprite; // The sprite for the cross object to display on the hit surface
    private SpriteRenderer crossRenderer;

    void Start()
    {
        GameObject crossObject = new GameObject("Cross");
        crossRenderer = crossObject.AddComponent<SpriteRenderer>();
        crossRenderer.sprite = crossSprite;
        crossObject.transform.parent = transform;
        crossObject.SetActive(false);
    }

    void Update()
    {
        // Create a ray from the knife position and in the direction of the knife's forward vector
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Check if the ray hits any colliders within a distance of raycastDistance units
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Show the cross and position it at the point of impact
            Vector3 hitPoint = hit.point;
            crossRenderer.transform.position = hitPoint;
            crossRenderer.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
            crossRenderer.enabled = true;
        }
        else
        {
            // Hide the cross if the ray does not hit anything
            crossRenderer.enabled = false;
        }
        Debug.DrawLine(transform.position, hit.point, Color.red);
    }
}
