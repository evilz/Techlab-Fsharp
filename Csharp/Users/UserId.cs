namespace ShopOnCore.Users
{
    public class UserId
    {
        private readonly string _id;

        public UserId(string id)
        {
            _id = id;
        }

        public string Value => _id;

        public override string ToString()
        {
            return $"UserID{{id='{_id}{'\''}{'}'}";
        }
    }
}
