using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class RawMPUSaberController : MonoBehaviour
{
    /* ================= UDP ================= */
    UdpClient udp;
    IPEndPoint ep;

    /* ================= RAW DATA ================= */
    int gx;
    bool hasData;

    /* ================= ORIENTATION ================= */
    float pitchTarget;     // computed angle
    float pitchCurrent;    // applied angle

    /* ================= CONSTANTS ================= */
    const float GYRO_SCALE = 131f;
    const float MAX_DT = 0.02f;

    /* ================= LIMITS ================= */
    const float MAX_FORWARD_ANGLE = 140f;
    const float MAX_BACK_ANGLE = -30f;

    /* ================= SMOOTHING ================= */
    const float DEADZONE_VEL = 5f;        // deg/sec
    const float MAX_ROT_SPEED = 360f;     // deg/sec (visual smoothing)

    void Start()
    {
        udp = new UdpClient(10000);
        ep = new IPEndPoint(IPAddress.Any, 10000);
        udp.BeginReceive(OnReceive, null);

        pitchTarget = 0f;
        pitchCurrent = 0f;

        Debug.Log("[UNITY] Saber controller started (smooth + capped)");
    }

    void OnReceive(System.IAsyncResult ar)
    {
        byte[] data = udp.EndReceive(ar, ref ep);
        string msg = Encoding.ASCII.GetString(data).Trim();
        string[] p = msg.Split(' ');

        if (p.Length == 6)
        {
            int.TryParse(p[3], out gx); // gyro X only
            hasData = true;
        }

        udp.BeginReceive(OnReceive, null);
    }

    void Update()
    {
        if (!hasData) return;

        float dt = Mathf.Min(Time.deltaTime, MAX_DT);

        /* ===== GYRO RATE ===== */
        float gxds = gx / GYRO_SCALE;

        /* ===== DEADZONE (NO JITTER) ===== */
        if (Mathf.Abs(gxds) < DEADZONE_VEL)
            gxds = 0f;

        /* ===== INTEGRATE TARGET ===== */
        pitchTarget += gxds * dt;

        /* ===== HARD LIMIT ===== */
        pitchTarget = Mathf.Clamp(
            pitchTarget,
            MAX_BACK_ANGLE,
            MAX_FORWARD_ANGLE
        );

        /* ===== SMOOTH VISUAL MOTION ===== */
        pitchCurrent = Mathf.MoveTowards(
            pitchCurrent,
            pitchTarget,
            MAX_ROT_SPEED * dt
        );

        /* ===== APPLY ROTATION ===== */
        transform.localRotation =
            Quaternion.AngleAxis(pitchCurrent, Vector3.right);
    }

    void OnApplicationQuit()
    {
        udp.Close();
    }
}