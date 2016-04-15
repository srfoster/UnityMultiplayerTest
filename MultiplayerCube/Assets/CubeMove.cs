using UnityEngine;
using UnityEngine.Networking;

public class CubeMove : NetworkBehaviour
{
    [ClientCallback]
	void Update ()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 10);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * 10);
    }
}
