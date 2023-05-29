using System;

[Serializable]
public class FloatReference
{
    public bool useConstant;
    public FloatVariable variable;
    public float constantValue;

    public float value {
        get { return useConstant ? constantValue : variable.value; }
        set { variable.value = value; }
    }
}
