//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlotHooks.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Step
    {
        public Step()
        {
            this.Selections = new HashSet<Selection>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ordinal { get; set; }
        public int PlotHookID { get; set; }
    
        public virtual PlotHook PlotHook { get; set; }
        public virtual ICollection<Selection> Selections { get; set; }
    }
}
