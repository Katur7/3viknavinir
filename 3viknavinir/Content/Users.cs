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
    
    public partial class Users
    {
        public Users()
        {
            this.Discussion = new HashSet<Discussion>();
            this.Requests = new HashSet<Requests>();
            this.Translation = new HashSet<Translation>();
            this.Upvote = new HashSet<Upvote>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool isBannedUser { get; set; }
        public bool isAdmin { get; set; }
    
        public virtual ICollection<Discussion> Discussion { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
        public virtual ICollection<Translation> Translation { get; set; }
        public virtual ICollection<Upvote> Upvote { get; set; }
    }
}