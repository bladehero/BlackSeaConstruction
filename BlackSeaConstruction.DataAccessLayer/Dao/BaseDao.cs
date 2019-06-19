using BlackSeaConstruction.DataAccessLayer.Models;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BlackSeaConstruction.DataAccessLayer.Dao
{
    public class BaseDao<T> : DataAccessObject, IEnumerable<T>, IEnumerable where T : BaseEntity
    {
        protected string TableName { get; set; }

        public BaseDao(string table, IDbConnection connection) : base(connection)
        {
            TableName = table;
        }

        protected string SelectFromString => $"select * from {TableName}";

        public IEnumerator GetEnumerator() => FindAll().GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => FindAll().GetEnumerator();

        public int Count(bool withDeleted = false) => Connection.QueryFirstOrDefault<int>($"select count(Id) from {TableName}{(withDeleted ? string.Empty : " where IsDeleted = 0")}");

        public T FindById(int id) => Connection.QueryFirstOrDefault<T>($"select top 1 * from {TableName} where Id = {id}");
        public virtual IEnumerable<T> FindAll(bool withDeleted = false) => Connection.Query<T>($"{SelectFromString}{(withDeleted ? string.Empty : " where IsDeleted = 0")}");
        public virtual IEnumerable<T> Find(Func<T, bool> predicate, bool withDeleted = false) => Connection.Query<T>($"{SelectFromString}{(withDeleted ? string.Empty : " where IsDeleted = 0")}").Where(predicate);
        public virtual T FirstOrDefault(Func<T, bool> predicate, bool withDeleted = false) => Connection.QueryFirstOrDefault<T>($"select top 1 * from {TableName}{(withDeleted ? string.Empty : " where IsDeleted = 0")}");
        public virtual IEnumerable<T> Take(int count, int skip = 0, bool withDeleted = false)
        {
            return Connection.Query<T>($"{SelectFromString}{(withDeleted ? string.Empty : " where IsDeleted = 0")} order by Id desc offset ({skip}) rows fetch next ({count}) rows only");
        }

        public virtual IEnumerable<T> Random(int count, bool withDeleted = false)
        {
            var items = FindAll(withDeleted);
            if (count > Count())
            {
                return items;
            }
            else
            {
                Random random = new Random();
                var itemList = items.ToList();
                var randomList = new List<T>(count);

                for (int i = 0; i < count;)
                {
                    int next = random.Next(items.Count());
                    if (!randomList.Contains(itemList[next]))
                    {
                        randomList.Add(itemList[next]);
                        i++;
                    }
                }
                return randomList;
            }
        }
        public virtual T FirstOrDefaultRandom(bool withDeleted = false)
        {
            var count = Count();
            if (count == 0)
            {
                return null;
            }
            Random random = new Random();
            return FindAll(withDeleted).ToList()[random.Next(count)];
        }

        public virtual int Insert(T item)
        {
            var properties = item.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);
            var sql = $"insert into {TableName} ({string.Join(",", properties.Select(x => x.Name))}) values ({string.Join(",", properties.Select(x => "@" + x.Name))}) SELECT CAST(SCOPE_IDENTITY() as int)";
            return item.Id = Connection.Query<int>(sql, item).Single();
        }
        public virtual bool Update(T item)
        {
            var properties = item.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);
            var sql = $"update {TableName} set {string.Join(",", properties.Select(x => x.Name + " = @" + x.Name))} where Id = @Id";
            return Connection.Execute(sql, item) > 0;
        }
        public virtual bool Delete(int id) => Connection.Execute($"update {TableName} set IsDeleted = 1, DateModified = getdate() where Id = {id}") > 0;
        public virtual bool Delete(T item) => Delete(item.Id);
        public virtual bool Restore(int id) => Connection.Execute($"update {TableName} set IsDeleted = 0, DateModified = getdate() where Id = {id}") > 0;
        public virtual bool Restore(T item) => Restore(item.Id);
        public virtual bool Merge(T item) => item?.Id == 0 ? Insert(item) > 0 : Update(item);

        protected IEnumerable<T> Query(string sql) => Connection.Query<T>(sql);
        protected T QueryFirstOrDefault(string sql) => Connection.QueryFirstOrDefault<T>(sql);
    }
}
