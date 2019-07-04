using UnityEngine;
using System.Collections;


public class SendJoyConOnUpdate : MonoBehaviour {

	public OSC osc;
    private Joycon j;

    // Values made available via Unity
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public Quaternion orientation;

    // Use this for initialization
    void Start () {
        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon object attached to the JoyconManager in scene
        j = JoyconManager.Instance.j;
    }
	
	// Update is called once per frame
	void Update () {

        stick = j.GetStick();

        // Gyro values: x, y, z axis values (in radians per second)
        gyro = j.GetGyro();

        // Accel values:  x, y, z axis values (in Gs)
        accel = j.GetAccel();

        orientation = j.GetVector();

        OscMessage message = new OscMessage();

        message.address = "/UpdateXYZ";
        message.values.Add(transform.position.x);
        message.values.Add(transform.position.y);
        message.values.Add(transform.position.z);
        osc.Send(message);

        message = new OscMessage();
        message.address = "/UpdateGyro";
        message.values.Add(gyro[0]);
        message.values.Add(gyro[1]);
        message.values.Add(gyro[2]);
        osc.Send(message);

        message = new OscMessage();
        message.address = "/UpdateAccel";
        message.values.Add(accel[0]);
        message.values.Add(accel[1]);
        message.values.Add(accel[2]);
        osc.Send(message);

        message = new OscMessage();
        message.address = "/UpdateOri";
        message.values.Add(orientation[0]);
        message.values.Add(orientation[1]);
        message.values.Add(orientation[2]);
        message.values.Add(orientation[3]);
        osc.Send(message);

        message = new OscMessage();
        message.address = "/UpdateStick";
        message.values.Add(stick[0]);
        message.values.Add(stick[1]);
        osc.Send(message);


    }


}
