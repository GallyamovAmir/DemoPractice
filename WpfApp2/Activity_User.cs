//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity_User
    {
        public int IDActivityUser { get; set; }
        public int activityID { get; set; }
        public int userID { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }
    }
}