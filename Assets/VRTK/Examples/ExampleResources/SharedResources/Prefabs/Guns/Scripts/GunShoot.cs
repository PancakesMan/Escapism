namespace VRTK.Examples
{
    using UnityEngine;

    public class GunShoot : MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        public VRTK_SnapDropZone AmmoBarrel;
        public GameObject projectile;
        public Transform projectileSpawnPoint;
        public float projectileSpeed = 1000f;
        public float projectileLife = 5f;

        public int MaxBullets = 6;
        private int BulletCount;

        private void Start()
        {
            BulletCount = MaxBullets;
            AmmoBarrel.ObjectSnappedToDropZone += AmmoInserted;
        }

        private void AmmoInserted(object sender, SnapDropZoneEventArgs e)
        {
            GameObject obj = AmmoBarrel.GetCurrentSnappedObject();
            if (obj)
            {
                AmmoBarrel.ForceUnsnap();
                Destroy(obj);
                Reload();
            }
        }

        protected virtual void OnEnable()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            }
        }

        protected virtual void OnDisable()
        {
            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }
        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
            if (BulletCount > 0)
            {
                BulletCount--;
                FireProjectile();
            }
        }

        protected virtual void FireProjectile()
        {
            if (projectile != null && projectileSpawnPoint != null)
            {
                GameObject clonedProjectile = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                Rigidbody projectileRigidbody = clonedProjectile.GetComponent<Rigidbody>();
                float destroyTime = 0f;
                if (projectileRigidbody != null)
                {
                    projectileRigidbody.AddForce(clonedProjectile.transform.forward * projectileSpeed);
                    destroyTime = projectileLife;
                }
                Destroy(clonedProjectile, destroyTime);
            }
        }

        public void Reload()
        {
            BulletCount = MaxBullets;
        }
    }
}