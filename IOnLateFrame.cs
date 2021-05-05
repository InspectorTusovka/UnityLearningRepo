namespace Code.CodeExtentions
{
    internal interface IOnLateFrame : IController
    {
        void OnLateFrame(float deltaTime);
    }
}