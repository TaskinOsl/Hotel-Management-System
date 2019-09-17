namespace Model.HMS.ViewModel
{
    public class UserProfileVm
    {
        public virtual string NickName { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual string AspNetUserId { get; set; }
    }
}