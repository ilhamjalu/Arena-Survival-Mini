using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer gunRenderer;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] public Transform firePoint;
    [SerializeField] public List<WeaponDirection> visuals;

    private Dictionary<Direction, WeaponDirection> visualMap;
    private Coroutine muzzleRoutine;

    // Start is called before the first frame update
    void Start()
    {
        visualMap = new Dictionary<Direction, WeaponDirection>();

        foreach (var visual in visuals)
        {
            visualMap.Add(visual.direction, visual);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDirection(Vector2 direction)
    {
        Direction currentDirection = GetDirection(direction);

        ApplyVisual(visualMap[currentDirection]);
    }

    private Direction GetDirection(Vector2 direction)
    {
        float absX = Mathf.Abs(direction.x);

        float absY = Mathf.Abs(direction.y);

        if (absX > absY)
        {
            gunRenderer.flipX = direction.x > 0;

            if(direction.x < 0)
            {
                return Direction.Left;
            }

            return Direction.Right;
        }

        if (direction.y > 0)
        {
            return Direction.Up;
        }

        return Direction.Down;
    }

    private void ApplyVisual(WeaponDirection visual)
    {
        firePoint.localPosition = visual.muzzleLocalPosition;

        gunRenderer.sprite = visual.gunSprite;

        gunTransform.localPosition = visual.gunLocalPosition;

        muzzlePoint.localPosition = visual.muzzleLocalPosition;

        muzzlePoint.localRotation = visual.muzzleLocalRotation;

        PlayMuzzleFlash();
    }

    public void PlayMuzzleFlash()
    {
        if (muzzleRoutine != null)
        {
            StopCoroutine(muzzleRoutine);
        }

        muzzleRoutine = StartCoroutine(MuzzleFlashRoutine());
    }

    private IEnumerator MuzzleFlashRoutine()
    {
        muzzlePoint.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        muzzlePoint.gameObject.SetActive(false);

        muzzleRoutine = null;
    }
}
