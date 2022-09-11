namespace SaveSystem
{
    [System.Serializable]
    public class UserInputData
    {
        private string _data;

        public string Data => _data;
    
        public UserInputData(string data)
        {
            _data = data;
        }
    }
}
