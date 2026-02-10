using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ESP32_UDP_Receiver : MonoBehaviour
{
    public int port = 5005;
    UdpClient udp;
    Thread receiveThread;

    public Vector3 data;

    void Start()
    {
        udp = new UdpClient(port);
        receiveThread = new Thread(ReceiveLoop);
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    void ReceiveLoop()
    {
        while (true)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);
            byte[] bytes = udp.Receive(ref ep);
            string msg = Encoding.ASCII.GetString(bytes);

            string[] v = msg.Split(',');
            data.x = float.Parse(v[0]);
            data.y = float.Parse(v[1]);
            data.z = float.Parse(v[2]);
        }
    }

    void OnApplicationQuit()
    {
        receiveThread.Abort();
        udp.Close();
    }
}
