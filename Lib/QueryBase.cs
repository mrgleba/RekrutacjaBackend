using System;
using System.Collections.Generic;

namespace Weles
{
    public interface ISelect
    {
        IGroupByOrOrderBy<T> Select<T>(T val, out T x);
        IGroupByOrOrderBy<T> Select<T>(T val);
    }

    public interface IWhere
    {
        IWhereOrSelect Where(bool cond);
    }

    public interface IWhereOrSelect : ISelect, IWhere
    {
    }

    public interface IJoin
    {
        IJoinCond LeftJoin<T>(IQ<T> t, out T x);
        IJoinCond InnerJoin<T>(IQ<T> t, out T x);
        IJoinCond RightJoin<T>(IQ<T> t, out T x);
    }

    public interface IJoinCond
    {
        IJoinOrWhereOrSelect On(bool c);
    }

    public interface IJoinOrWhereOrSelect : IJoin, IWhereOrSelect
    {
    }

    public interface IGroupBy<T> : IQQ<T>
    {
        IGroupByOrOrderBy<T> GroupBy(object? o);
    }

    public interface IOrderBy<T> : IQQ<T>
    {
        IOrderBy<T> OrderBy(object? o, string? collation = null);
        IOrderBy<T> OrderByDesc(object? o, string? collation = null);
    }

    public interface IGroupByOrOrderBy<T> : IOrderBy<T>, IGroupBy<T>
    {
    }

    public interface IWhereM
    {
        IWhereM Where(bool cond);
    }

    public interface IFrom
    {
        IJoinOrWhereOrSelect From<T>(IQ<T> t, out T x);
    }
    public interface IQ<T>
    { }

    public interface IQQ<T> : IQ<T>
    {
    }
    public interface IQT<T> : IQ<T>
    {

    }

    public interface IQuery<T> : IQQ<T>
    {
        IEnumerable<object> Into(T v);
        void IntoSingle(T v);

    }

    public class InAttribute : Attribute {}
    public class OutAttribute : Attribute {}
    public abstract class QueryBase<Q>
    {
        public abstract IQuery<T> Query<T>(Func<IFrom, IQQ<T>> f);
        public abstract Q C { get; }

        public abstract bool IsNull<T>(T o);
        public abstract bool IsNotNull<T>(T o);
        public abstract bool IsDF<T>(T o1, T o2);
        public abstract bool IsNDF<T>(T o1, T o2);

        public abstract bool Exists<T>(IQQ<T> par);
        public abstract string? List<T>(T o, string? sep = null, int? blen = null);
        public abstract T Min<T>(T o);
        public abstract T Max<T>(T o);
        public abstract T Sum<T>(T o);
        public abstract T MinValue<T>(params T[] p);
        public abstract T MaxValue<T>(params T[] p);
        public abstract int Count();
        public abstract string? Concat(params object?[] pars);
        public abstract string AsciChar(int num);
        public abstract int CastInt<T>(T war);
        public abstract DateTime CastDate<T>(T war);
        public abstract DateTime CastTimestamp<T>(T war);

        public abstract void DeclareDecimal(out decimal? x);
        public abstract void DeclareString(out string? x);
        public abstract void Suspend();
        public abstract int RowCount { get; }
    }
}
