using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material newMaterial;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setAlienToBlack();
    }

    void Start()
    {
        setAlienToBlack();
    }

    private void setAlienToBlack()
    {
        if (gameObject.name == "CitizenAlien1" && GameManager.Instance.Citizen1Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "CitizenAlien2" && GameManager.Instance.Citizen2Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "CitizenAlien3" && GameManager.Instance.Citizen3Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "CitizenAlien4" && GameManager.Instance.Citizen4Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "CitizenAlien5" && GameManager.Instance.Citizen5Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "DoctorAlien1" && GameManager.Instance.Doctor1Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "DoctorAlien2" && GameManager.Instance.Doctor2Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "DoctorAlien3" && GameManager.Instance.Doctor3Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "DoctorAlien4" && GameManager.Instance.Doctor4Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "DoctorAlien5" && GameManager.Instance.Doctor5Touched)
        {
            setBlack();
        }
        else if (gameObject.name == "SuperiorAlien" && GameManager.Instance.SuperiorTouched)
        {
            setBlack();
        }
    }

    private void setBlack()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.material = newMaterial;
        }
    }
}