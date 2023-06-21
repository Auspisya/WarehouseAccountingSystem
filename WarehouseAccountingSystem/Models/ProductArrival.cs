//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WarehouseAccountingSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductArrival
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int ProviderId { get; set; }
        public string ProcurationNumber { get; set; }
        public System.DateTime ProcurationDateOfIssue { get; set; }
        public int EmployeeAcceptedId { get; set; }
        public System.DateTime ArrivalDate { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }
    }
}