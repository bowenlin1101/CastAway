using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatMessage
{
    private string message;
    private string image;

    public ChatMessage(string image, string message)
    {
        this.Message = message;
        this.Image = image;
    }

    public string Message
    {
        get { return message; }
        set { message = value; }
    }

    public string Image
    {
        get { return image; }
        set { image = value; }
    }
}
