//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace schoolWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductOtherPhoto
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public Nullable<int> IdProduct { get; set; }
    
        public virtual Product Product { get; set; }
    }
}