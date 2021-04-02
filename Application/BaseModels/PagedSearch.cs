using System;
using System.Collections.Generic;
using System.Text;

namespace MikroServisProizvod.Application.BaseModels
{
    public abstract class PagedSearch : ILoggableObject
    {
        public bool IsPagedResponse { get; set; }
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
