using System;
using System.Collections.Generic;
using System.Linq;

namespace Weles
{
    public class PrzykladBController
    {
        public
            IEnumerable<(string depKey, int depId, string depNaz,
                IEnumerable<(string pracKey, int pracId, string pracNaz)>)>
        Pracownicy() => 
            from x in GetPracFromDB()
            group (x.pracId, x.pracNaz) by (x.depId, x.depNaz) into x
            select (
                $"d{x.Key.depId}",
                x.Key.depId,
                x.Key.depNaz,
                from y in x
                select (
                    $"p{y.pracId}",
                    y.pracId,
                    y.pracNaz
                )
            );


        // Pracownicy w departamentach - posortowane wg depId
        protected IEnumerable<(int depId, string depNaz, int pracId, string pracNaz)> GetPracFromDB() => Enumerable.Empty<(int depId, string depNaz, int pracId, string pracNaz)>();

        // Kontrakty klientów - posortowane wg kliId, kontrId
        protected IEnumerable<(int kliId, string kliNaz, int kontrId, string kontrNr, int kontrPozLp, string towNaz, decimal kwota)> GetKontraktFromDb() => Enumerable.Empty<(int kliId, string kliNaz, int kontrId, string kontrNr, int kontrPozLp, string towNaz, decimal kwota)>();

        public virtual
            IEnumerable<(string kliKey, int kliId, string kliNaz,
                IEnumerable<(string kontrKey, int kontrId, string kontrNr,
                    IEnumerable<(string kontrPozKey, int kontrPozLp, string towNaz, decimal kwota)>)>)>
        Kontrakty()
        {
            throw new NotImplementedException();
        }
    }
}
