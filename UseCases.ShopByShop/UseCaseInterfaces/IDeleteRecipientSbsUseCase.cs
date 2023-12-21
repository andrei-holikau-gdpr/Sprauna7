namespace UseCases.ShopByShop.UseCaseInterfaces
{
    public interface IDeleteRecipientSbsUseCase
    {
        Task<bool> ExecuteAsync(int id);
    }
}