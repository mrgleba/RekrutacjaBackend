using System;

namespace Weles
{
    public abstract partial class PrzykladA : Weles.Query 
    {
        /*
        select d.nazwa depNaz, count(*) c
        from departament d
        group by d.nazwa
        */

        IQuery<(string depNaz, int c)> LiczbaPracownikowWDepartamencie() => Query(q => q.
            From(C.Departament, out var d).
            Select((naz: d.nazwa, Count()), out var q1).
            GroupBy(q1.naz));

        /*
        select d.nazwa depNaz, sum(o.kwota) war
        from departament d
            inner join pracownik p on p.depId = d.id
            inner join kontrakt k on k.pracId = p.id
            inner join kontraktpozycja o on o.kontrId = k.id
        group by d.nazwa
        */

        Weles.IQuery<(string depNaz, decimal war)> KwotaKontraktowWDepartamencie() => Query(q => q.
            From(C.Departament, out var d).
                InnerJoin(C.Pracownik, out var p).On(p.depId == d.id).
                InnerJoin(C.Kontrakt, out var k).On(k.pracId == p.id).
                InnerJoin(C.KontraktPozycja, out var o).On(o.kontrId == k.id).
            Select((naz: d.nazwa, Sum(o.kwota)), out var q1).
            GroupBy(q1.naz));


        /*
        select pc.depNaz, dp.c
        from (
            select pc.depNaz, pc.c
            from (
                select d.nazwa depNaz, count(*) c
                from departament d
                group by d.nazwa) pc
            where pc.c > @cnt) pc
            inner join (
                select d.nazwa depNaz, sum(o.kwota) war
                from departament d
                    inner join pracownik p on p.depId = d.id
                    inner join kontrakt k on k.pracId = p.id
                    inner join kontraktpozycja o on o.kontrId = k.id
                group by d.nazwa) kw on kw.depNaz = pc.depNaz
        */

        // Kwota kontraktów i liczba pracowników w departamentach mających ponad cnt pracowników
        Weles.IQuery<(string depNaz, int c, decimal war)> KontrWarPracCntDep(int cnt) => Query(q => q.
            From(Query(q => q.
                From(LiczbaPracownikowWDepartamencie(), out var pc).
                Where(pc.c > cnt).
                Select((pc.depNaz, pc.c))), out var pc).
                InnerJoin(KwotaKontraktowWDepartamencie(), out var kw).On(kw.depNaz == pc.depNaz)
            .Select((pc.depNaz, pc.c, kw.war)));
    }
}
