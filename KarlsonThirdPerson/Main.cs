using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(KarlsonThirdPerson.Main), "Third Person", "1.0.0", "Xiloe#0001")]
[assembly: MelonGame("Dani", "Karlson")]

namespace KarlsonThirdPerson
{
    public class Main : MelonMod
    {
        public bool thirdPerson = false;
        private GameObject player;
        private MeshRenderer bean;
        private GameObject camera;
        private EZCameraShake.CameraShaker cameraShake;

        public override void OnLevelWasLoaded(int level)
        {
            if (level >= 2)
            {
                if (!camera && !player && !bean && !cameraShake)
                {
                    camera = GameObject.Find("Camera");
                    player = GameObject.Find("Player");
                    bean = player.GetComponent<MeshRenderer>();
                    cameraShake = GameObject.Find("Camera").transform.Find("Main Camera").GetComponent<EZCameraShake.CameraShaker>();
                }

                if (camera && bean && cameraShake)
                {
                    bean.enabled = true;
                    cameraShake.enabled = false;
                }
            }
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyUp(KeyCode.M))
                thirdPerson = !thirdPerson;

            if (camera)
            {
                camera.transform.Find("Main Camera").localPosition = thirdPerson ? new Vector3(0, 1.5f, -6f) : new Vector3(0, 0, 0);
                camera.transform.Find("Main Camera/GunCam").localPosition = thirdPerson ? new Vector3(0, 1f, -10f) : new Vector3(0, 0, 0);
            }
        }
    }
}
