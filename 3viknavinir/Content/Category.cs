//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _3viknavinir.Content
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public Category()
        {
            this.Media = new HashSet<Media>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public byte[] poster { get; set; }
    
        public virtual ICollection<Media> Media { get; set; }
    }
}
