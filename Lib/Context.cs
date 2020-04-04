namespace Weles
{
    public interface IContext
    {
        IQT<(int id, string nazwa)> Departament { get; }
        IQT<(int id, string imieNazwisko, int depId)> Pracownik { get; }
        IQT<(int id, string nazwa)> Klient { get; }
        IQT<(int id, string nazwa)> Towar { get; }
        IQT<(int id, string nr, int pracId, int kliId)> Kontrakt { get; }
        IQT<(int kontrId, int lp, int towarId, decimal kwota)> KontraktPozycja { get; }
    }

    public abstract class Query : QueryBase<IContext> 
    {

    }
}