﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCUserRoomReserver.Models.db_model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class reserveRoomEntities1 : DbContext
    {
        public reserveRoomEntities1()
            : base("name=reserveRoomEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<sp_RBU_Result> sp_RBU(Nullable<int> p_id)
        {
            var p_idParameter = p_id.HasValue ?
                new ObjectParameter("p_id", p_id) :
                new ObjectParameter("p_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RBU_Result>("sp_RBU", p_idParameter);
        }
    
        public virtual ObjectResult<sp_RBD_Result> sp_RBD(Nullable<System.DateTime> p_fi, Nullable<System.DateTime> p_ff)
        {
            var p_fiParameter = p_fi.HasValue ?
                new ObjectParameter("p_fi", p_fi) :
                new ObjectParameter("p_fi", typeof(System.DateTime));
    
            var p_ffParameter = p_ff.HasValue ?
                new ObjectParameter("p_ff", p_ff) :
                new ObjectParameter("p_ff", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RBD_Result>("sp_RBD", p_fiParameter, p_ffParameter);
        }
    
        public virtual ObjectResult<sp_getRooms_Result> sp_getRooms()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getRooms_Result>("sp_getRooms");
        }
    
        public virtual ObjectResult<sp_getUsers_Result> sp_getUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getUsers_Result>("sp_getUsers");
        }
    }
}
