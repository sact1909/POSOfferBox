namespace POSOfferBox.BL.EngineCore.Abstract
{
    public interface IBusinessEngineFactory
    {
        T GetBusinessEngine<T>() where T : IBusinessEngine;
    }
}
