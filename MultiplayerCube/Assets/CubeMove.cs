using UnityEngine;
using UnityEngine.Networking;

public class CubeMove : NetworkBehaviour
{
    [SyncVar(hook = "SetColor")]
    Color color;

    [ServerCallback]
    void Awake()
    {
        color = new Color(Random.value, Random.value, Random.value);
    }

    void SetColor(Color c)
    {
        color = c;
        GetComponent<Renderer>().material.color = color;
    }

    [ClientCallback]
	void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * 10;
            GetComponent<Rigidbody>().velocity = velocity;

            //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 10);
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * 10);
        }
    }
}
