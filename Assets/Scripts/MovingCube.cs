using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    float distance;
    float moveSpeed;
    [SerializeField] GameObject breakEffect;

    public void CubeSpawned(float _dist, float _speed)
    {
        transform.position = new Vector3(0, 0.55f, -3);
        distance = _dist;
        moveSpeed = _speed;
        GetComponent<Renderer>().material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(distance, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
        if(transform.position.x == distance)
        {
            ToDestroyCube();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "MoveCube" || collision.collider.tag == "Wall")
        {
            ToDestroyCube();
        }
    }
    void ToDestroyCube()
    {
        var effect = Instantiate(breakEffect);
        effect.transform.position = gameObject.transform.position;
        effect.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<MeshRenderer>().material.color;
        Destroy(gameObject);
    }
}
