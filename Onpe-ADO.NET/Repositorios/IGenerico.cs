namespace Onpe_ADO.NET.Repositorios
{
    public interface IGenerico<T> where T : class
    {
        Task<List<T>> Lista();
    }
}
