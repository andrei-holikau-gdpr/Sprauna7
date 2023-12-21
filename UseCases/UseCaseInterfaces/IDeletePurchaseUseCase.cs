namespace UseCases.UseCaseInterfaces
{
    public interface IDeletePurchaseUseCase
    {
        void Delete(int purchaseId, string currentUserId);
    }
}