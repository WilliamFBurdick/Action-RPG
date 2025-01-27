using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    [ExecuteAlways]
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;

        void LateUpdate()
        {
            if (target != null)
            {
                transform.position = target.position;
            }
        }
    }
}
