using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;

namespace Entities.Tests.Common
{
    public static class QueyableExtensions
    {
        public static void Mock<T>(this Mock<DbSet<T>> mock) where T : class
        {
            var collection = new List<T>();
            var queryable = collection.AsQueryable();
            mock.Setup(m => m.Add(It.IsAny<T>())).Callback((T dbEntity) =>
            {
                collection.Add(dbEntity);
            });
            mock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mock.As<IQueryable<T>>().Setup(pm => pm.GetEnumerator()).Returns(collection.GetEnumerator());
            mock.As<IQueryable>().Setup(pm => pm.GetEnumerator()).Returns(collection.GetEnumerator());
        }
    }
}
