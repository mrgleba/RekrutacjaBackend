using System;
using System.Collections.Generic;

namespace Weles
{
    partial class PrzykladA
    {
        /*
        execute block returns (string depNaz, string pracNaz, decimal maxWar) as
        declare imnaz string;
        declare war decimal;
        begin
            for select d.nazwa
                from departament d
                into depnaz
            do begin
                maxWar = 0;
                for select p.imieNazwisko, sum(o.kwota)
                    from pracownik p
                        inner join kontrakt k on k.pracId = p.id
                        inner join kontraktpozycja o on o.kontrId = k.id
                    group by p.imieNazwisko
                    into imnaz, war
                do begin
                    if (war > maxWar) then begin
                        maxWar = war;
                        pracNaz = imnaz;
                    end
                end
                if (maxWar > 0) then
                    suspend();
            end
        end
        */
        void NajlepszyPracownikWDepartamencie([Out]string depNaz, [Out]string pracNaz, [Out]decimal maxWar)
        {
            foreach (var _1 in Query(q => q.
                 From(C.Departament, out var d).
                 Select(d.nazwa)).Into(depNaz))
            {
                DeclareString(out var imnaz);
                DeclareDecimal(out var war);
                maxWar = 0;

                foreach (var _2 in Query(q => q.
                    From(C.Pracownik, out var p).
                        InnerJoin(C.Kontrakt, out var k).On(k.pracId == p.id).
                        InnerJoin(C.KontraktPozycja, out var o).On(o.kontrId == k.id).
                    Select((p.imieNazwisko, Sum(o.kwota)), out var q1).
                    GroupBy(q1.imieNazwisko)).
                    Into((imnaz!, war!.Value)))
                {
                    if (war.Value > maxWar)
                    {
                        maxWar = war.Value;
                        pracNaz = imnaz!;
                    }
                }

                if (maxWar > 0)
                    Suspend();
            }
        }
    }
}
