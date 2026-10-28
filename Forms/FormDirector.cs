using RoleAuthorizationLab3.Data;

namespace RoleAuthorizationLab3.Forms
{
    public class FormDirector : RoleFormBase
    {
        public FormDirector(User user) : base(user, "Директора")
        {
        }
    }
}
