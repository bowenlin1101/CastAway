using System.Collections;
using UnityEngine;

public class EmptyBoxScript : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.instructionText.text = "";
        if (GameManager.Instance.keyStatus > 0) {
            Destroy(this.gameObject);
        }
        setDestroyBox();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.Instance.instructionText != null)
        {
            GameManager.Instance.setInstructionCanvasActive(true);
            GameManager.Instance.instructionText.text = "That box was empty!";
            StartCoroutine(ClearTextAfterDelay(1));
        }
        if (gameObject.name == "closedBox1")
        {
            GameManager.Instance.closedBox1Touched = true;
        }
        else if (gameObject.name == "closedBox2")
        {
            GameManager.Instance.closedBox2Touched = true;
        }
        else if (gameObject.name == "closedBox3")
        {
            GameManager.Instance.closedBox3Touched = true;
        }
        else if (gameObject.name == "closedBox4")
        {
            GameManager.Instance.closedBox4Touched = true;
        }
        else if (gameObject.name == "closedBox5")
        {
            GameManager.Instance.closedBox5Touched = true;
        }
        else if (gameObject.name == "closedBox6")
        {
            GameManager.Instance.closedBox6Touched = true;
        }
        else if (gameObject.name == "closedBox7")
        {
            GameManager.Instance.closedBox7Touched = true;
        }
        else if (gameObject.name == "closedBox8")
        {
            GameManager.Instance.closedBox8Touched = true;
        }
        else if (gameObject.name == "closedBox9")
        {
            GameManager.Instance.closedBox9Touched = true;
        }
        else if (gameObject.name == "closedBox10")
        {
            GameManager.Instance.closedBox10Touched = true;
        }
        else if (gameObject.name == "closedBox11")
        {
            GameManager.Instance.closedBox11Touched = true;
        }
        else if (gameObject.name == "KeyBox")
        {
            GameManager.Instance.KeyBoxTouched = true;
        }

        setDestroyBox();
    }

    private void setDestroyBox()
    {
        if (gameObject.name == "closedBox1" && GameManager.Instance.closedBox1Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox2" && GameManager.Instance.closedBox2Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox3" && GameManager.Instance.closedBox3Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox4" && GameManager.Instance.closedBox4Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox5" && GameManager.Instance.closedBox5Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox6" && GameManager.Instance.closedBox6Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox7" && GameManager.Instance.closedBox7Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox8" && GameManager.Instance.closedBox8Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox9" && GameManager.Instance.closedBox9Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox10" && GameManager.Instance.closedBox10Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "closedBox11" && GameManager.Instance.closedBox11Touched)
        {
            Destroy(this.gameObject);
        }
        else if (gameObject.name == "KeyBox" && GameManager.Instance.KeyBoxTouched)
        {
            Destroy(this.gameObject);
        }
    }


    private IEnumerator ClearTextAfterDelay(float delay)
    {

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = false; // Make the object invisible
        }
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        GameManager.Instance.instructionText.text = ""; // Clear the text
        GameManager.Instance.setInstructionCanvasActive(false);
        Destroy(gameObject);

    }
    void Update()
    {
        if (GameManager.Instance.keyStatus != 0)
        {
            foreach (GameObject box in GameObject.FindGameObjectsWithTag("EmptyBox"))
            {
                Destroy(box);
            }
            Destroy(GameObject.FindWithTag("KeyBox"));
        }
    }

}
