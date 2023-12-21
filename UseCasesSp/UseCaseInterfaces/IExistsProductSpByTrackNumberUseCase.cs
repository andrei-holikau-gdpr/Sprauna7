namespace UseCasesSp.UseCaseInterfaces
{
    public interface IExistsProductSpByTrackNumberUseCase
    {
        bool Execute(string TrackNumber);
    }
}