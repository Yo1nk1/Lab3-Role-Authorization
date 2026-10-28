using RoleAuthorizationLab3.Data;

namespace RoleAuthorizationLab3.Forms
{
    public class FormSeller : RoleFormBase
    {
        public FormSeller(User user) : base(user, "Продавца")
        {
        }
    }
}
