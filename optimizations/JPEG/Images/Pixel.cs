namespace JPEG.Images;

public struct Pixel(float firstComponent, float secondComponent, float thirdComponent)
{
    public float Value1 = firstComponent;
    public float Value2 = secondComponent;
    public float Value3 = thirdComponent;
}