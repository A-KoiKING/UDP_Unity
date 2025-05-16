using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class ClientExample : MonoBehaviour
{
    [SerializeField]
    string host = "127.0.0.1";
    private int port1 = 64276;
    private UdpClient client;

    void Start()
    {
        client = new UdpClient();
        client.Connect(host, port1);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Send");
            var message = Encoding.UTF8.GetBytes("Hello World!");
            client.Send(message, message.Length);
        }
    }

    private void OnDestroy()
    {
        client.Close();
    }
}