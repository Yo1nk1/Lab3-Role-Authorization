using RoleAuthorizationLab3.Data;

namespace RoleAuthorizationLab3.Forms
{
    public class FormManager : RoleFormBase
    {
        public FormManager(User user) : base(user, "Менеджера")
        {
        }
    }
}
